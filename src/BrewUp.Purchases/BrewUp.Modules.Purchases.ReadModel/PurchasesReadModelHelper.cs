using BrewUp.Modules.Purchases.ReadModel.EventHandlers;
using MediatR.NotificationPublishers;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Purchases.ReadModel;

public static class PurchasesReadModelHelper
{
	public static IServiceCollection AddPurchasesReadModel(this IServiceCollection services)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(typeof(PurchaseOrderCreatedEventHandler).Assembly);
			cfg.NotificationPublisher = new ForeachAwaitPublisher();
		});

		return services;
	}
}