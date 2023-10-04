using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderStatusChangedToCompleteForReadModelEventHandler : DomainEventHandlerBase<PurchaseOrderStatusChangedToComplete>
{
	public PurchaseOrderStatusChangedToCompleteForReadModelEventHandler()
	{
	}

	public override Task Handle(PurchaseOrderStatusChangedToComplete @event, CancellationToken cancellationToken)
	{
		// Update readModel
		return Task.CompletedTask;
	}
}