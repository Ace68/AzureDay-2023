using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.BindingModels;

public static class Helpers
{
	public static Shared.Dtos.OrderLine ToDto(this OrderLine orderLine)
	{
		return new Shared.Dtos.OrderLine
		{
			BeerId = new BeerId(orderLine.ProductId),
			BeerName = new BeerName(orderLine.Title),
			Quantity = new Shared.Dtos.Quantity
			{
				Value = orderLine.Quantity.Value,
				UnitOfMeasure = orderLine.Quantity.UnitOfMeasure
			},
			Price = new Shared.Dtos.Price
			{
				Value = orderLine.Price.Value,
				Currency = orderLine.Price.Currency
			}
		};
	}

	public static IEnumerable<Shared.Dtos.OrderLine> ToDto(this IEnumerable<OrderLine> orderLines) => orderLines.Select(ToDto);
}