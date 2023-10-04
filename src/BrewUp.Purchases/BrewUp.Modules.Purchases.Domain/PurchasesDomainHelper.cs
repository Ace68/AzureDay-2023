using BrewUp.Modules.Purchases.Domain.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Purchases.Domain;

public static class PurchasesDomainHelper
{
	public static IServiceCollection AddPurchasesDomain(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreatePurchaseOrderCommandHandler).Assembly));

		return services;
	}
}