using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.ReadModel.EventHandlers;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Events;

public class PurchaseOrderCreatedConsumer : DomainEventConsumerBase<PurchaseOrderCreated>
{
    protected override IEnumerable<IDomainEventHandlerAsync<PurchaseOrderCreated>> HandlersAsync { get; }
    
    public PurchaseOrderCreatedConsumer(AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory, 
        ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<PurchaseOrderCreated>>
        {
            new PurchaseOrderCreatedEventHandler(loggerFactory),
            new PurchaseOrderCreatedSendEmailEventHandler(loggerFactory)
        };
    }
}