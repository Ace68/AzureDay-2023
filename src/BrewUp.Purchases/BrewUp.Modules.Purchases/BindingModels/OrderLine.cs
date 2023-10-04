namespace BrewUp.Modules.Purchases.BindingModels;

public class OrderLine
{
	public Guid ProductId { get; set; }
	public string Title { get; set; } = string.Empty;
	public Quantity Quantity { get; set; } = default!;
	public Price Price { get; set; } = default!;
}