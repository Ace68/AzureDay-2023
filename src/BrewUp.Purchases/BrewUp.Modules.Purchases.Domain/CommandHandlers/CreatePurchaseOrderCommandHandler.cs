using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Modules.Purchases.Messages.Commands;
using Microsoft.Extensions.Logging;
using Muflone;
using Muflone.Persistence;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public sealed class CreatePurchaseOrderCommandHandler : CommandHandlerBaseAsync<CreatePurchaseOrder>
{

	public CreatePurchaseOrderCommandHandler(IRepository repository, 
		ILoggerFactory loggerFactory) : base(repository, loggerFactory)
	{
	}

	public override async Task ProcessCommand(CreatePurchaseOrder command, CancellationToken cancellationToken = default)
	{
		var aggregate = PurchaseOrder.CreatePurchaseOrder(command.PurchaseOrderId, command.SupplierId, command.Date, command.Lines);
		await Repository.SaveAsync(aggregate, Guid.NewGuid());
	}
}