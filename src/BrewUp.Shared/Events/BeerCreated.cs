using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Shared.Events;

public record BeerCreated : DomainEvent
{
	public readonly BeerId BeerId;
	public readonly BeerName BeerName;

	public BeerCreated(BeerId BeerId, BeerName beerName) : base(BeerId)
	{
		this.BeerId = BeerId;
		BeerName = beerName;
	}
}