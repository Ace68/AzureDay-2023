using BrewUp.Modules.Purchases.Messages.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public sealed class PurchaseOrderCreatedSendEmailEventHandler : DomainEventHandlerAsync<PurchaseOrderCreated>
{
	public PurchaseOrderCreatedSendEmailEventHandler(ILoggerFactory loggerFactory) :
		base(loggerFactory)
	{
	}

	public override Task HandleAsync(PurchaseOrderCreated @event, CancellationToken cancellationToken = default)
	{
		//Send order via email to our supplier....

		return Task.CompletedTask;
	}
}