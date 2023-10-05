using BrewUp.Shared.Commands;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Events;
using Muflone.Persistence;
using Muflone.Saga;

namespace BrewUp.Modules.Sagas;

public sealed class BeersReceivedSaga :
	ISagaStartedByAsync<StartBeersReceivedSaga>,
	ISagaEventHandlerAsync<BeerCreated>,
	ISagaEventHandlerAsync<BeerLoadedInStock>
{

	private readonly IServiceBus _serviceBus;

	public BeersReceivedSaga(IServiceBus serviceBus)
	{
		_serviceBus = serviceBus;
	}
	
	public async Task StartedByAsync(StartBeersReceivedSaga command)
	{
		foreach (var orderLine in command.OrderLines)
		{
			var createBeer = new CreateBeer(orderLine.BeerId, orderLine.BeerName);
			await _serviceBus.SendAsync(createBeer, CancellationToken.None);
		}
	}

	public async Task HandleAsync(BeerCreated @event)
	{
		var loadBeerInStock = new LoadBeerInStock(@event.BeerId, new Stock(1),
			new Price
			{
				Currency = "EUR",
				Value = 1
			},
			new PurchaseOrderId(Guid.NewGuid()));
		await _serviceBus.SendAsync(loadBeerInStock, CancellationToken.None);
	}

	public Task HandleAsync(BeerLoadedInStock @event)
	{
		// Send email, update warehouse, etc.
		return Task.CompletedTask;
	}

	public void Dispose()
	{
	}
}

public class BeersReceivedSagaState
{
	public string PurchaseOrderId { get; set; } = string.Empty;

	public IEnumerable<OrderLine> OrderLines { get; set; } = Enumerable.Empty<OrderLine>();

	public DateTime StartedAt { get; set; } = DateTime.MinValue;
	public DateTime FinishedAt { get; set; } = DateTime.MinValue;
}