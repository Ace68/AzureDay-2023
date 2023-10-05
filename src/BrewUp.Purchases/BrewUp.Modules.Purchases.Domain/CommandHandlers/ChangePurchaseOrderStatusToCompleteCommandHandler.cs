using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Modules.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public sealed class ChangePurchaseOrderStatusToCompleteCommandHandler : CommandHandlerBaseAsync<ChangePurchaseOrderStatusToComplete>
{

	public ChangePurchaseOrderStatusToCompleteCommandHandler(IRepository repository, ILoggerFactory loggerFactory) :
		base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(ChangePurchaseOrderStatusToComplete command, CancellationToken cancellationToken = default)
	{
		// Aggregate Factory
		var aggregate = await Repository.GetByIdAsync<PurchaseOrder>(command.PurchaseOrderId.Value);
		aggregate.ChangePurchaseOrderStatusToComplete(command.PurchaseOrderId);
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}