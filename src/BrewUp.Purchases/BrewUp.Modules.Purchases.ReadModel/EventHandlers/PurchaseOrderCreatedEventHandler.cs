using BrewUp.Modules.Purchases.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderCreatedEventHandler : DomainEventHandlerAsync<PurchaseOrderCreated>
{
	public PurchaseOrderCreatedEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}

	public override Task HandleAsync(PurchaseOrderCreated @event, CancellationToken cancellationToken = new CancellationToken())
	{
		// Update the read model
		return Task.CompletedTask;
	}
}