using BrewUp.Shared.DomainIds;

namespace BrewUp.Shared.Dtos;

public class OrderLine
{
	public BeerId BeerId { get; set; } = default!;
	public BeerName BeerName { get; set; } = default!;
	public Quantity Quantity { get; set; } = default!;
	public Price Price { get; set; } = default!;
}