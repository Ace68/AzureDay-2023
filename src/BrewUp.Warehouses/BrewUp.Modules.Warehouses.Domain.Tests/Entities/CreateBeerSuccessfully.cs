using BrewUp.Modules.Warehouses.Domain.CommandHandlers;
using BrewUp.Shared.Commands;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging.Abstractions;
using Muflone.Messages.Commands;
using Muflone.Messages.Events;
using Muflone.SpecificationTests;

namespace BrewUp.Modules.Warehouses.Domain.Tests.Entities;

public sealed class CreateBeerSuccessfully : CommandSpecification<CreateBeer>
{
    private readonly BeerId _beerId = new (Guid.NewGuid());
    private readonly BeerName _beerName = new ("BeerName");
    
    protected override IEnumerable<DomainEvent> Given()
    {
        yield break;
    }

    protected override CreateBeer When()
    {
        return new CreateBeer(_beerId, _beerName);
    }

    protected override ICommandHandlerAsync<CreateBeer> OnHandler()
    {
        return new CreateBeerCommandHandler(Repository, new NullLoggerFactory());
    }

    protected override IEnumerable<DomainEvent> Expect()
    {
        yield return new BeerCreated(_beerId, _beerName);
    }
}