using BrewUp.Shared.Commands;
using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;
using Muflone.Persistence;

namespace BrewUp.Modules.Sagas.Adapters;

public sealed class BeersReceivedEventHandler : IntegrationEventHandlerAsync<BeersReceived>
{
	private readonly IServiceBus _serviceBus;

	public BeersReceivedEventHandler(IServiceBus serviceBus, ILoggerFactory loggerFactory) : base(loggerFactory)
	{
		_serviceBus = serviceBus;
	}

	public override async Task HandleAsync(BeersReceived @event, CancellationToken cancellationToken = new ())
	{
		var command = new StartBeersReceivedSaga(@event.PurchaseOrderId, @event.OrderLines);
		await _serviceBus.SendAsync(command, cancellationToken);
	}
}