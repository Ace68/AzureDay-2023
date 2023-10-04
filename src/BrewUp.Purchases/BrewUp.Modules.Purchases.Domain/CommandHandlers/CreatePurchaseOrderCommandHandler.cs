using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Shared.Abstracts;
using MediatR;

namespace BrewUp.Modules.Purchases.Domain.CommandHandlers;

public sealed class CreatePurchaseOrderCommandHandler : CommandHandlerBase<CreatePurchaseOrder>
{
	private readonly IPublisher _serviceBus;

	public CreatePurchaseOrderCommandHandler(IPublisher serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(CreatePurchaseOrder command, CancellationToken cancellationToken)
	{
		// Do something with the command
		var purchaseOrderCreated = PurchaseOrder.RaisePurchaseOrderCreated(command.PurchaseOrderId, command.SupplierId, command.Date, command.Lines);
		await _serviceBus.Publish(purchaseOrderCreated, cancellationToken);
	}
}