using BrewUp.Modules.Purchases.Domain.Entities;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.Domain.Helpers;

internal static class DomainHelper
{
    internal static IEnumerable<PurchaseLine> ToDomainEntities(this IEnumerable<OrderLine> lines)
    {
        return lines.Select(l => PurchaseLine.CreatePurchaseLine(l.BeerId, l.BeerName, l.Quantity, l.Price));
    }
    
    internal static IEnumerable<OrderLine> ToDtos(this IEnumerable<PurchaseLine> lines)
    {
        return lines.Select(l => new OrderLine
        {
            BeerId = l.BeerId,
            BeerName = l.BeerName,
            Quantity = l.Quantity,
            Price = l.Price
        });
    }
}