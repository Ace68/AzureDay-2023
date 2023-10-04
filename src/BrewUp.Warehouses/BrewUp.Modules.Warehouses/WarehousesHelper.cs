using BrewUp.Modules.Warehouses.Domain;
using BrewUp.Modules.Warehouses.ReadModel;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Warehouses;

public static class WarehousesHelper
{
	public static IServiceCollection AddWarehousesModule(this IServiceCollection services)
	{
		services.AddWarehousesDomain();
		services.AddWarehousesReadModel();

		return services;
	}
}