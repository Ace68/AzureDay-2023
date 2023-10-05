using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.ReadModel.EventHandlers;

public class PurchaseOrderStatusChangedToCompleteEventHandler : DomainEventHandlerAsync<PurchaseOrderStatusChangedToComplete>
{
	private readonly IEventBus _eventBus;

	public PurchaseOrderStatusChangedToCompleteEventHandler(IEventBus eventBus, ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		_eventBus = eventBus;
	}

	public override async Task HandleAsync(PurchaseOrderStatusChangedToComplete @event,
		CancellationToken cancellationToken = new ())
	{
		var beersReceived = new BeersReceived(@event.PurchaseOrderId, @event.Lines);
		await _eventBus.PublishAsync(beersReceived, cancellationToken);
	}
}