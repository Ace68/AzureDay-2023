using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderCreatedEventHandler : DomainEventHandlerBase<PurchaseOrderCreated>
{
	public override Task Handle(PurchaseOrderCreated @event, CancellationToken cancellationToken)
	{
		// Update the read model
		return Task.CompletedTask;
	}
}