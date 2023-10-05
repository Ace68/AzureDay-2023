using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.ReadModel.EventHandlers;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Events;

public class PurchaseOrderStatusChangedToCompleteConsumer : DomainEventConsumerBase<PurchaseOrderStatusChangedToComplete>
{
    protected override IEnumerable<IDomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>> HandlersAsync { get; }

    public PurchaseOrderStatusChangedToCompleteConsumer(IEventBus eventBus,
        AzureServiceBusConfiguration azureServiceBusConfiguration, ILoggerFactory loggerFactory,
        ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
    {
        HandlersAsync = new List<IDomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>>
        {
            new PurchaseOrderStatusChangedToCompleteForReadModelEventHandler(loggerFactory),
            new PurchaseOrderStatusChangedToCompleteEventHandler(eventBus, loggerFactory)
        };
    }
}