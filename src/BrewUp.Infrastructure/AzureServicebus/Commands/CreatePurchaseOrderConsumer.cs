using BrewUp.Modules.Purchases.Domain.CommandHandlers;
using BrewUp.Modules.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Commands;

public class CreatePurchaseOrderConsumer : CommandConsumerBase<CreatePurchaseOrder>
{
    protected override ICommandHandlerAsync<CreatePurchaseOrder> HandlerAsync { get; }

    public CreatePurchaseOrderConsumer(IRepository repository, AzureServiceBusConfiguration azureServiceBusConfiguration,
        ILoggerFactory loggerFactory) : base(azureServiceBusConfiguration, loggerFactory)
    {
        HandlerAsync = new CreatePurchaseOrderCommandHandler(repository, loggerFactory);
    }
}