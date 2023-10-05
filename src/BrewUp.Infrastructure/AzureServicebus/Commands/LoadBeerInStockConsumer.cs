using BrewUp.Modules.Warehouses.Domain.CommandHandlers;
using BrewUp.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Commands;

public sealed class LoadBeerInStockConsumer : CommandConsumerBase<LoadBeerInStock>
{
    protected override ICommandHandlerAsync<LoadBeerInStock> HandlerAsync { get; }
    
    public LoadBeerInStockConsumer(IRepository repository, AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory, ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
    {
        HandlerAsync = new LoadBeerInStockCommandHandler(repository, loggerFactory);
    }
}