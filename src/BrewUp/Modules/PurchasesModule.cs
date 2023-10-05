using BrewUp.Modules.Purchases;
using BrewUp.Modules.Purchases.Endpoints;

namespace BrewUp.Modules;

public class PurchasesModule : IModule
{
	public bool IsEnabled => true;
	public int Order => 20;

	public IServiceCollection RegisterModule(WebApplicationBuilder builder)
	{
		builder.Services.AddPurchases();

		return builder.Services;
	}

	public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
	{
		var group = endpoints.MapGroup("/v1/Purchases/")
			.WithTags("Purchases");

		group.MapPost("/Order", PurchasesEndpoints.HandleCreateOrder)
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status201Created)
			.WithName("CreateOrder");

		group.MapPut("/Order/{id}/complete", PurchasesEndpoints.HandleSetOrderStatusToComplete)
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status200OK)
			.WithName("SetStatusToComplete");

		group.MapGet("/Order", PurchasesEndpoints.HandleGetPurchasesOrders)
			.Produces(StatusCodes.Status400BadRequest)
			.Produces(StatusCodes.Status201Created)
			.WithName("GetOrders");

		return endpoints;
	}
}