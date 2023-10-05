using BrewUp.Modules.Sagas;
using BrewUp.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;
using Muflone.Saga;
using Muflone.Transport.Azure.Models;
using Muflone.Transport.Azure.Saga.Consumers;

namespace BrewUp.Infrastructure.AzureServicebus.Commands;

public sealed class StartBeersReceivedSagaConsumer : SagaStartedByConsumerBase<StartBeersReceivedSaga>
{
    protected override ISagaStartedByAsync<StartBeersReceivedSaga> HandlerAsync { get; }

    public StartBeersReceivedSagaConsumer(IServiceBus serviceBus,
        AzureServiceBusConfiguration azureServiceBusConfiguration, ILoggerFactory loggerFactory,
        ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
    {
        HandlerAsync = new BeersReceivedSaga(serviceBus);
    }
}