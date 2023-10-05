using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Events;

public class BeerCreated : DomainEvent
{
	public readonly BeerId BeerId;
	public readonly BeerName BeerName;

	public BeerCreated(BeerId beerId, BeerName beerName) : base(beerId)
	{
		BeerId = beerId;
		BeerName = beerName;
	}
}