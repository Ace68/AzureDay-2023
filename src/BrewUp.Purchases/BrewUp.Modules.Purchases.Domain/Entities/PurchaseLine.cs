using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Modules.Purchases.Domain.Entities;

public class PurchaseLine : Entity
{ 
    internal BeerId BeerId { get; private set; }
    internal BeerName BeerName { get; private set; }  
    internal Quantity Quantity  { get; private set; }
    internal Price Price  { get; private set; }

    protected PurchaseLine()
    {
        BeerId = default!;
        BeerName = default!;
        Quantity = default!;
        Price = default!;
    }

    internal static PurchaseLine CreatePurchaseLine(BeerId beerId, BeerName beerName, Quantity quantity, Price price)
    {
        return new PurchaseLine
        {
            BeerId = beerId,
            BeerName = beerName,
            Quantity = quantity,
            Price = price
        };
    }
}