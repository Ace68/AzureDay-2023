namespace BrewUp.Shared.Dtos;

public record OrderLineJson(string BeerId, string BeerName, Quantity Quantity, Price Price);