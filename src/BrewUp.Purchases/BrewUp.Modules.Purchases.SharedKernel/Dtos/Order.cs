using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.SharedKernel.Dtos;

public class Order
{
	public Guid SupplierId { get; set; }
	public DateTime Date { get; set; }
	public IEnumerable<OrderLine> Lines { get; set; }
	public Guid Id { get; }

	public Order()
	{
		Id = Guid.NewGuid();
	}
}