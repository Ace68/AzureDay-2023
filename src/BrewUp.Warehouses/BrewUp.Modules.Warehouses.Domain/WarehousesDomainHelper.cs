using BrewUp.Modules.Warehouses.Domain.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Warehouses.Domain;

public static class WarehousesDomainHelper
{
	public static IServiceCollection AddWarehousesDomain(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateBeerCommandHandler).Assembly));

		return services;
	}
}