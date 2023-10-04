using Microsoft.FeatureManagement;

namespace BrewUp.Modules;

public static class ModuleExtensions
{
	private static readonly IList<IModule> RegisteredModules = new List<IModule>();

	public static WebApplicationBuilder RegisterModules(this WebApplicationBuilder builder)
	{
		builder.Services.AddFeatureManagement(builder.Configuration.GetSection("BrewUp:FeatureManagement"));

		var modules = DiscoverModules();
		modules = modules.Where(m => m.IsEnabled)
			.OrderBy(m => m.Order);

		foreach (var module in modules)
		{
			module.RegisterModule(builder);
			RegisteredModules.Add(module);
		}

		return builder;
	}

	public static WebApplication MapEndpoints(this WebApplication app)
	{
		foreach (var module in RegisteredModules)
		{
			module.MapEndpoints(app);
		}

		return app;
	}

	private static IEnumerable<IModule> DiscoverModules()
	{
		return typeof(IModule).Assembly
			.GetTypes()
			.Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
			.Select(Activator.CreateInstance)
			.Cast<IModule>();
	}
}