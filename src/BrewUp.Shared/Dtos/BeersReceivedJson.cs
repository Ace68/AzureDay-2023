namespace BrewUp.Shared.Dtos;

public class BeersReceivedJson
{
	public string OrderId { get; set; } = string.Empty;
	public IEnumerable<OrderLineJson> OrderLines { get; set; } = Enumerable.Empty<OrderLineJson>();
}