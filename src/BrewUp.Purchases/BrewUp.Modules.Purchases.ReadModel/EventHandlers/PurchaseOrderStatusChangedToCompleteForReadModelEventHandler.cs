using BrewUp.Modules.Purchases.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderStatusChangedToCompleteForReadModelEventHandler : DomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>
{
	public PurchaseOrderStatusChangedToCompleteForReadModelEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}

	public override Task HandleAsync(PurchaseOrderStatusChangedToComplete @event,
		CancellationToken cancellationToken = new ())
	{
		// Update readModel
		return Task.CompletedTask;
	}
}