using BrewUp.Modules.Sagas;
using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Transport.Azure.Models;
using Muflone.Transport.Azure.Saga.Consumers;

namespace BrewUp.Infrastructure.AzureServicebus.Events;

public sealed class BeerCratedSagaConsumer : SagaEventConsumerBase<BeerCreated>
{
    protected override ISagaEventHandlerAsync<BeerCreated> HandlerAsync { get; }

    public BeerCratedSagaConsumer(IServiceBus serviceBus, AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory, ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration,
        loggerFactory, messageSerializer)
    {
        HandlerAsync = new BeersReceivedSaga(serviceBus);
    }
}