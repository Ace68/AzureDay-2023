namespace BrewUp.Shared.Dtos;

public class BeerJson
{
	public string BeerId { get; set; } = string.Empty;
	public string BeerName { get; set; } = string.Empty;
	public decimal Stock { get; set; } = 0;
	public decimal Availability { get; set; } = 0;
	public Price Price { get; set; } = default!;
}