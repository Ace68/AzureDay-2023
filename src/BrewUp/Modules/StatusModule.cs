using BrewUp.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BrewUp.Modules;

public sealed class StatusModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 0;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddHealthChecks();
		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		endpoints.MapHealthChecks("/health/api", new HealthCheckOptions()
		{
			ResponseWriter = HealthCheckHelper.WriteResponse
		});

		return endpoints;
	}
}