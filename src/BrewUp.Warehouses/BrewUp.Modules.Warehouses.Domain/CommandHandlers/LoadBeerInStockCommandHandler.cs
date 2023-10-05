using BrewUp.Modules.Warehouses.Domain.Entities;
using BrewUp.Shared.Commands;
using Microsoft.Extensions.Logging;
using Muflone.Persistence;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public sealed class LoadBeerInStockCommandHandler : CommandHandlerBaseAsync<LoadBeerInStock>
{
	public LoadBeerInStockCommandHandler(IRepository repository, ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(LoadBeerInStock command, CancellationToken cancellationToken = default)
	{
		var aggregate = await Repository.GetByIdAsync<Beer>(command.BeerId.Value);
		aggregate.LoadBeerInStock(command.BeerId, command.Stock, command.Price, command.PurchaseOrderId);
		
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}