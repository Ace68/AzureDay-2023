using BrewUp.Modules.Warehouses.Domain.CommandHandlers;
using BrewUp.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Commands;

public class CreateBeerConsumer : CommandConsumerBase<CreateBeer>
{
    protected override ICommandHandlerAsync<CreateBeer> HandlerAsync { get; }

    public CreateBeerConsumer(IRepository repository, AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory, ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration,
        loggerFactory, messageSerializer)
    {
        HandlerAsync = new CreateBeerCommandHandler(repository, loggerFactory);
    }
}