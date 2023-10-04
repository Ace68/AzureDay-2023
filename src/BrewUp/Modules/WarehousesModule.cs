using BrewUp.Modules.Warehouses;

namespace BrewUp.Modules;

public class WarehousesModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 0;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddWarehousesModule();

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		endpoints.MapGet("v1/warehouses", () => Results.Ok())
			.WithTags("Warehouses");

		return endpoints;
	}
}