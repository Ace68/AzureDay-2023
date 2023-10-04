using BrewUp.Shared.Commands;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Events;
using MediatR;

namespace BrewUp.Modules.Sagas;

public sealed class BeersReceivedSaga :
	IRequestHandler<StartBeersReceivedSaga>,
	INotificationHandler<BeerCreated>,
	INotificationHandler<BeerLoadedInStock>
{

	private readonly IMediator _serviceBus;

	public BeersReceivedSaga(IMediator serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public async Task Handle(StartBeersReceivedSaga command, CancellationToken cancellationToken)
	{
		foreach (var orderLine in command.OrderLines)
		{
			var createBeer = new CreateBeer(orderLine.BeerId, orderLine.BeerName);
			await _serviceBus.Send(createBeer, cancellationToken);
		}
	}

	public async Task Handle(BeerCreated @event, CancellationToken cancellationToken)
	{
		var loadBeerInStock = new LoadBeerInStock(@event.BeerId, new Stock(1),
			new Price
			{
				Currency = "EUR",
				Value = 1
			},
			new PurchaseOrderId(Guid.NewGuid()));
		await _serviceBus.Send(loadBeerInStock, cancellationToken);
	}

	public Task Handle(BeerLoadedInStock @event, CancellationToken cancellationToken)
	{
		// Send email, update warehouse, etc.
		return Task.CompletedTask;
	}
}

public class BeersReceivedSagaState
{
	public string PurchaseOrderId { get; set; } = string.Empty;

	public IEnumerable<OrderLine> OrderLines { get; set; } = Enumerable.Empty<OrderLine>();

	public DateTime StartedAt { get; set; } = DateTime.MinValue;
	public DateTime FinishedAt { get; set; } = DateTime.MinValue;
}