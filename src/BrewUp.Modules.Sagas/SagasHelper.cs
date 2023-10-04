using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Modules.Sagas;

public static class SagasHelper
{
	public static IServiceCollection AddBrewUpSagas(this IServiceCollection services)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(BeersReceivedSaga).Assembly));

		return services;
	}
}