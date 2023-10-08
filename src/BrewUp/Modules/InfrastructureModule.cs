using BrewUp.Infrastructure;
using BrewUp.Infrastructure.AzureServicebus;
using BrewUp.Infrastructure.MongoDb;

namespace BrewUp.Modules;

public class InfrastructureModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 99;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure(builder.Configuration.GetSection("BrewUp:MongoDB").Get<MongoDbSettings>()!,
            builder.Configuration.GetSection("BrewUp:ServiceBusSettings").Get<ServiceBusSettings>()!,
            builder.Configuration["BrewUp:EventStore:ConnectionString"]!);

        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}