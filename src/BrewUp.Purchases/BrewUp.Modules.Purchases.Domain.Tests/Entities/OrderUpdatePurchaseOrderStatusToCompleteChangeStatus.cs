using BrewUp.Modules.Purchases.Domain.CommandHandlers;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Modules.Purchases.Domain.Tests.Entities;

public class OrderUpdatePurchaseOrderStatusToCompleteChangeStatus : CommandSpecification<ChangePurchaseOrderStatusToComplete>
{
	private readonly PurchaseOrderId _purchaseOrderId;
	private readonly SupplierId _supplierId;
	private readonly DateTime _date;
	private readonly IEnumerable<OrderLine> _lines = Enumerable.Empty<OrderLine>();

	public OrderUpdatePurchaseOrderStatusToCompleteChangeStatus()
	{
		_purchaseOrderId = new PurchaseOrderId(Guid.NewGuid());
		_supplierId = new SupplierId(Guid.NewGuid());
		_date = DateTime.Today;

		_lines = _lines.Concat(new List<OrderLine>
		{
			new()
			{
				BeerId = new BeerId(Guid.NewGuid()),
				BeerName = new BeerName("Product 1"),
				Quantity = new Quantity { UnitOfMeasure = "N.", Value = 1 },
				Price = new Price { Currency = "EUR", Value = 1 }
			},
			new()
			{
				BeerId = new BeerId(Guid.NewGuid()),
				BeerName = new BeerName("Product 2"),
				Quantity = new Quantity { UnitOfMeasure = "N.", Value = 2 },
				Price = new Price { Currency = "EUR", Value = 2 }
			}
		}).ToList();
	}

	protected override IEnumerable<DomainEvent> Given()
	{
		yield return new PurchaseOrderCreated(_purchaseOrderId, _supplierId, _date, _lines);
	}

	protected override ChangePurchaseOrderStatusToComplete When()
	{
		return new ChangePurchaseOrderStatusToComplete(_purchaseOrderId);
	}

	protected override ICommandHandlerAsync<ChangePurchaseOrderStatusToComplete> OnHandler()
	{
		return new ChangePurchaseOrderStatusToCompleteCommandHandler(Repository, new NullLoggerFactory());
	}

	protected override IEnumerable<DomainEvent> Expect()
	{
		yield return new PurchaseOrderStatusChangedToComplete(_purchaseOrderId, _lines);
	}
}