using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Commands;
using BrewUp.Shared.Events;
using MediatR;

namespace BrewUp.Modules.Sagas.Adapters;

public sealed class BeersReceivedEventHandler : IntegrationEventHandlerBase<BeersReceived>
{
	private readonly IMediator _serviceBus;

	public BeersReceivedEventHandler(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(BeersReceived @event, CancellationToken cancellationToken)
	{
		var command = new StartBeersReceivedSaga(@event.PurchaseOrderId, @event.OrderLines);
		await _serviceBus.Send(command, cancellationToken);
	}
}