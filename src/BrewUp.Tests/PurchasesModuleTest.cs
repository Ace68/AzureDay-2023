using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BrewUp.Modules.Purchases.BindingModels;
using Xunit;

namespace BrewUp.Tests;

[Collection("Integration Fixture")]
public class PurchasesModuleTest
{
	private readonly AppHttpClientFixture _integrationFixture;

	public PurchasesModuleTest(AppHttpClientFixture integrationFixture)
	{
		_integrationFixture = integrationFixture;
	}

	[Fact]
	public async Task Cannot_Send_InvalidJson()
	{
		var body = new Order
		{
			SupplierId = Guid.Empty,
			Date = DateTime.MinValue,
			Lines = Enumerable.Empty<OrderLine>()
		};

		var stringJson = JsonSerializer.Serialize(body);
		var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");
		var postResult = await _integrationFixture.Client.PostAsync("/v1/Purchases/Order", httpContent);

		Assert.Equal(HttpStatusCode.BadRequest, postResult.StatusCode);
	}
}