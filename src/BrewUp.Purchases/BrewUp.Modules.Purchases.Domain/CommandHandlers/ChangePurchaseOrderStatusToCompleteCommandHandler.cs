using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Shared.Abstracts;
using MediatR;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public sealed class ChangePurchaseOrderStatusToCompleteCommandHandler : CommandHandlerBase<ChangePurchaseOrderStatusToComplete>
{
	private readonly IPublisher _serviceBus;

	public ChangePurchaseOrderStatusToCompleteCommandHandler(IPublisher serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(ChangePurchaseOrderStatusToComplete command, CancellationToken cancellationToken)
	{
		// Aggregate Factory
		var purchaseOrderStatusCompleted = PurchaseOrder.ChangePurchaseOrderStatusToComplete(command.PurchaseOrderId);
		await _serviceBus.Publish(purchaseOrderStatusCompleted, cancellationToken);
	}
}