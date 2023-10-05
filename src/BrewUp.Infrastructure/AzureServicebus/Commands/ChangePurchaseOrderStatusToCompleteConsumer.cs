using BrewUp.Modules.Purchases.Domain.CommandHandlers;
using BrewUp.Modules.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Commands;
using Muflone.Persistence;
using Muflone.Transport.Azure.Consumers;
using Muflone.Transport.Azure.Models;

namespace BrewUp.Infrastructure.AzureServicebus.Commands;

public class ChangePurchaseOrderStatusToCompleteConsumer : CommandConsumerBase<ChangePurchaseOrderStatusToComplete>
{
    protected override ICommandHandlerAsync<ChangePurchaseOrderStatusToComplete> HandlerAsync { get; }

    public ChangePurchaseOrderStatusToCompleteConsumer(IRepository repository,
        AzureServiceBusConfiguration azureServiceBusConfiguration, ILoggerFactory loggerFactory,
        ISerializer? messageSerializer = null) : base(azureServiceBusConfiguration, loggerFactory, messageSerializer)
    {
        HandlerAsync = new ChangePurchaseOrderStatusToCompleteCommandHandler(repository, loggerFactory);
    }
}