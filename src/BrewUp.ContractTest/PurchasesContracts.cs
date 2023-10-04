using BrewUp.Modules.Purchases.BindingModels;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PactNet;
using PactNet.Output.Xunit;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BrewUp.ContractTest;

/// <summary>
/// https://github.com/DiUS/pact-workshop-dotnet-core-v3/
/// </summary>
public class PurchasesContracts
{
	private readonly IPactBuilderV3 _pactBuilder;
	private readonly Mock<IHttpClientFactory> _mockFactory;

	public PurchasesContracts(ITestOutputHelper output)
	{
		_mockFactory = new Mock<IHttpClientFactory>();

		var config = new PactConfig
		{
			PactDir = "../../../pacts/",
			Outputters = new[]
			{
				new XunitOutput(output)
			},
			DefaultJsonSettings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new JsonConverter[] { new StringEnumConverter() }
			},
			LogLevel = PactLogLevel.Debug
		};

		_pactBuilder = Pact.V3("BrewUp API", "Purchases Module", config).WithHttpInteractions();
	}

	[Fact]
	public async Task Should_Get_PurchasesOrders()
	{
		var purchaseOrder = new Order
		{
			SupplierId = Guid.NewGuid(),
			Date = DateTime.UtcNow,
			Lines = new List<OrderLine>
			{
				new()
				{
					ProductId = Guid.NewGuid(),
					Quantity = new Quantity(10, "Nr"),
					Price = new Price(10, "EUR")
				}
			}
		};
		var stringJson = JsonSerializer.Serialize(purchaseOrder);
		var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");

		_pactBuilder
			.UponReceiving("a request for purchases orders")
			.Given("a request without parameters")
			.WithRequest(HttpMethod.Get, "/v1/purchases/")
			.WithHeader("Accept", "application/json")
			.WillRespond()
			.WithStatus(HttpStatusCode.OK);

		await _pactBuilder.VerifyAsync(async ctx =>
		{
			_mockFactory
				.Setup(f => f.CreateClient("Purchases"))
				.Returns(() => new HttpClient
				{
					BaseAddress = ctx.MockServerUri,
					DefaultRequestHeaders =
					{
						Accept = { MediaTypeWithQualityHeaderValue.Parse("application/json") }
					}
				});


		});
	}
}