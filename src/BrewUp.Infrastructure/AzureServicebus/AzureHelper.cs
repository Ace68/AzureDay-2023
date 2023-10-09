using BrewUp.Infrastructure.AzureServicebus.Commands;
using BrewUp.Infrastructure.AzureServicebus.Events;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;
using Muflone.Transport.Azure;
using Muflone.Transport.Azure.Abstracts;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus;

public static class AzureHelper
{
    public static IServiceCollection AddAzureServiceBus(this IServiceCollection services,
        ServiceBusSettings serviceBusSettings)
    {
        var azureBusConfiguration =
            new AzureServiceBusConfiguration(serviceBusSettings.ConnectionString, nameof(CreatePurchaseOrder),
                serviceBusSettings.ClientId);
        services.AddMufloneTransportAzure(azureBusConfiguration);

        var serviceProvider = services.BuildServiceProvider();
        var repository = serviceProvider.GetRequiredService<IRepository>();
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        
        var consumers = new List<IConsumer>
        {
            new CreatePurchaseOrderConsumer(repository, azureBusConfiguration, loggerFactory),
            new PurchaseOrderCreatedConsumer(azureBusConfiguration, loggerFactory),
            
            new ChangePurchaseOrderStatusToCompleteConsumer(repository, azureBusConfiguration, loggerFactory),
            new PurchaseOrderStatusChangedToCompleteConsumer(serviceProvider.GetRequiredService<IEventBus>(), azureBusConfiguration, loggerFactory),
            
            new CreateBeerConsumer(repository, azureBusConfiguration, loggerFactory),
            new BeerCreatedConsumer(azureBusConfiguration, loggerFactory),
            new BeerCratedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(), azureBusConfiguration, loggerFactory),
            
            new LoadBeerInStockConsumer(repository, azureBusConfiguration, loggerFactory),
            
            new BeersReceivedConsumer(serviceProvider.GetRequiredService<IServiceBus>(), azureBusConfiguration, loggerFactory),
            new StartBeersReceivedSagaConsumer(serviceProvider.GetRequiredService<IServiceBus>(), azureBusConfiguration, loggerFactory),
        };

        services.RegisterConsumersInTransportAzureServiceBus(consumers);

        return services;
    }
}