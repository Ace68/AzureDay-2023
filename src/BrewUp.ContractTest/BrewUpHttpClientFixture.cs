using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace BrewUp.ContractTest;

public class BrewUpHttpClientFixture : IDisposable
{
	public readonly HttpClient Client;

	public BrewUpHttpClientFixture()
	{
		var app = new ProjectsApplication();
		Client = app.CreateClient();
		Client.BaseAddress = new Uri("http://localhost:4200/v1/");
	}

	private class ProjectsApplication : WebApplicationFactory<Program>
	{
		protected override IHost CreateHost(IHostBuilder builder)
		{
			builder.ConfigureHostConfiguration(_ =>
			{
			});

			return base.CreateHost(builder);
		}
	}

	#region Dispose

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!disposing) return;
		Client.Dispose();
	}

	#endregion
}