using BrewUp.Modules.Sagas;
using BrewUp.Modules.Warehouses.ReadModel.EventHandlers;
using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Events;

public sealed class BeerCreatedConsumer : DomainEventConsumerBase<BeerCreated>
{
    protected override IEnumerable<IDomainEventHandlerAsync<BeerCreated>> HandlersAsync { get; }

    public BeerCreatedConsumer(AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory, ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration,
        loggerFactory, messageSerializer)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<BeerCreated>>
        {
            new BeerCreatedEventHandler(loggerFactory)
        };
    }
}