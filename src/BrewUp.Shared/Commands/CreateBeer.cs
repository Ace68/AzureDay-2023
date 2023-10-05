using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Commands;

public class CreateBeer : Command
{
	public readonly BeerId BeerId;
	public readonly BeerName BeerName;

	public CreateBeer(BeerId aggregateId, BeerName beerName) : base(aggregateId)
	{
		BeerId = aggregateId;
		BeerName = beerName;
	}
}