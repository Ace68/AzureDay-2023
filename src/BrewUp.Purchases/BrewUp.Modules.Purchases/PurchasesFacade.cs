using BrewUp.Modules.Purchases.BindingModels;
using BrewUp.Modules.Purchases.Messages.Commands;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.DomainIds;
using Muflone.Persistence;

namespace BrewUp.Modules.Purchases;

public sealed class PurchasesFacade : IPurchasesFacade
{
	private readonly IServiceBus _serviceBus;

	public PurchasesFacade(IServiceBus serviceBus)
	{
		_serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
	}

	public async Task<string> CreateOrderAsync(Order order, CancellationToken cancellationToken)
	{
		//Application level validation
		var createOrder = new CreatePurchaseOrder(new PurchaseOrderId(order.Id),
			new SupplierId(order.SupplierId), order.Date,
			order.Lines.ToDto());

		await _serviceBus.SendAsync(createOrder, cancellationToken);

		return order.Id.ToString();
	}

	public async Task ChangeStatusToComplete(Guid id, CancellationToken cancellationToken)
	{
		var command = new ChangePurchaseOrderStatusToComplete(new PurchaseOrderId(id));

		await _serviceBus.SendAsync(command, cancellationToken);
	}

	public Task<IEnumerable<Order>> GetPurchasesOrdersAsync(CancellationToken cancellationToken)
	{
		var orders = new List<Order>
		{
			new()
			{
				SupplierId = Guid.NewGuid(),
				Date = DateTime.UtcNow,
				Lines = new List<OrderLine>
				{
					new()
					{
						ProductId = Guid.NewGuid(),
						Quantity = new Quantity(10, "Nr"),
						Price = new Price(10, "EUR")
					},
					new()
					{
						ProductId = Guid.NewGuid(),
						Quantity = new Quantity(5, "Nr"),
						Price = new Price(8, "EUR")
					}
				}
			}
		};

		return Task.FromResult<IEnumerable<Order>>(orders);
	}
}