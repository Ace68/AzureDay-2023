using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Commands;
using BrewUp.Shared.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public sealed class LoadBeerInStockCommandHandler : CommandHandlerBase<LoadBeerInStock>
{
	private readonly IPublisher _serviceBus;

	public LoadBeerInStockCommandHandler(IPublisher serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(LoadBeerInStock command, CancellationToken cancellationToken)
	{
		var beerLoadedInStock = new BeerLoadedInStock(command.BeerId, command.Stock, command.Price, command.PurchaseOrderId);
		await _serviceBus.Publish(beerLoadedInStock, cancellationToken);
	}
}