using BrewUp.Modules.Warehouses.ReadModel.EventHandlers;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Warehouses.ReadModel;

public static class WarehousesReadModelHelper
{
	public static IServiceCollection AddWarehousesReadModel(this IServiceCollection services)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(typeof(BeerCreatedEventHandler).Assembly);
			cfg.NotificationPublisher = new ForeachAwaitPublisher();
		});

		return services;
	}
}