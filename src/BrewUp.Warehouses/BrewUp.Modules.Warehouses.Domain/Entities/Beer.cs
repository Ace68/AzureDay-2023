using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using BrewUp.Shared.Events;
using Muflone.Core;

namespace BrewUp.Modules.Warehouses.Domain.Entities;

public class Beer : AggregateRoot
{
    private BeerId _beerId = default!;
    private BeerName _beerName = default!;

    protected Beer()
    {
    }

    private Beer(BeerId beerId, BeerName beerName)
    {
        RaiseEvent(new BeerCreated(beerId, beerName));
    }

    internal static Beer CreateBeer(BeerId beerId, BeerName beerName)
    {
        return new Beer(beerId, beerName);
    }
    
    private void Apply(BeerCreated @event)
    {
        Id = @event.BeerId;
        
        _beerId = @event.BeerId;
        _beerName = @event.BeerName;
    }

    internal void LoadBeerInStock(BeerId beerId, Stock stock, Price price, PurchaseOrderId purchaseOrderId)
    {
        RaiseEvent(new BeerLoadedInStock(beerId, stock, price, purchaseOrderId));
    }

    private void Apply(BeerLoadedInStock @event)
    {
        
    }
}
    