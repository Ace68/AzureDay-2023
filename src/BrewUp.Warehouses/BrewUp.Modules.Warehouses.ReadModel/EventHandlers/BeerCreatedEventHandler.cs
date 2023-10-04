using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Events;

namespace BrewUp.Modules.Warehouses.ReadModel.EventHandlers;

public class BeerCreatedEventHandler : DomainEventHandlerBase<BeerCreated>
{
	public override Task Handle(BeerCreated notification, CancellationToken cancellationToken)
	{
		// Update read model
		return Task.CompletedTask;
	}
}