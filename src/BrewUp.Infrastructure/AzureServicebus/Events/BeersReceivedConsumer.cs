using BrewUp.Modules.Sagas.Adapters;
using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Events;

public sealed class BeersReceivedConsumer : IntegrationEventConsumerBase<BeersReceived>
{
    protected override IEnumerable<IIntegrationEventHandlerAsync<BeersReceived>> HandlersAsync { get; }

    public BeersReceivedConsumer(IServiceBus serviceBus, AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory, ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration,
        loggerFactory, messageSerializer)
    {
        HandlersAsync = new List<IIntegrationEventHandlerAsync<BeersReceived>>
        {
            new BeersReceivedEventHandler(serviceBus, loggerFactory)
        };
    }
}