namespace BrewUp.Modules.Purchases.BindingModels;

public class Order
{
	public Guid SupplierId { get; set; }
	public DateTime Date { get; set; }
	public IEnumerable<OrderLine> Lines { get; set; } = Enumerable.Empty<OrderLine>();
	public Guid Id { get; } = Guid.NewGuid();
}