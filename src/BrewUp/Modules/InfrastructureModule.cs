namespace BrewUp.Modules;

public class InfrastructureModule : IModule
{
    public bool IsEnabled => true;
    public int Order => 99;
    
    public IServiceCollection RegisterModule(WebApplicationBuilder builder)
    {
       
        return builder.Services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) => endpoints;
}