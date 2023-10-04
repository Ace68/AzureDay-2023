using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Shared.Commands;

public record CreateBeer : Command
{
	public readonly BeerId BeerId;
	public readonly BeerName BeerName;

	public CreateBeer(BeerId aggregateId, BeerName beerName) : base(aggregateId)
	{
		BeerId = aggregateId;
		BeerName = beerName;
	}
}