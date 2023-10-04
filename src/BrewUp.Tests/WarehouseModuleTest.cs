using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BrewUp.Tests;

[Collection("Integration Fixture")]
public class WarehouseModuleTest
{
	private readonly AppHttpClientFixture _integrationFixture;

	public WarehouseModuleTest(AppHttpClientFixture integrationFixture)
	{
		_integrationFixture = integrationFixture;
	}

	[Fact]
	public async Task Should_Get_BeersInStorage()
	{
		var postResult = await _integrationFixture.Client.GetAsync("/v1/warehouses");

		Assert.Equal(HttpStatusCode.OK, postResult.StatusCode);
	}
}