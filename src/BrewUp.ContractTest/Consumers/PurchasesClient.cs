using System.Text;
using System.Text.Json;

namespace BrewUp.ContractTest.Consumers;

public class PurchasesClient
{
	private readonly BrewUpHttpClientFixture _clientFixture;

	public PurchasesClient(BrewUpHttpClientFixture clientFixture)
	{
		_clientFixture = clientFixture;
	}

	public async Task<HttpResponseMessage> CreateOrder()
	{
		using var client = new HttpClient();

		var purchaseOrder = new Modules.Purchases.BindingModels.Order
		{
			SupplierId = Guid.NewGuid(),
			Date = DateTime.UtcNow,
			Lines = new[]
			{
				new Modules.Purchases.BindingModels.OrderLine
				{
					ProductId = Guid.NewGuid(),
					Quantity = new Modules.Purchases.BindingModels.Quantity(10, "Nr"),
					Price = new Modules.Purchases.BindingModels.Price(10, "EUR")
				}
			}
		};
		var stringJson = JsonSerializer.Serialize(purchaseOrder);
		var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");

		return await client.PostAsync(new Uri(_baseUri, "/v1/Purchases/Order"), httpContent);
	}

	public async Task<HttpResponseMessage> GetOrders()
	{
		using var client = new HttpClient();
		client.BaseAddress = _baseUri;

		var purchaseOrder = new Modules.Purchases.BindingModels.Order
		{
			SupplierId = Guid.NewGuid(),
			Date = DateTime.UtcNow,
			Lines = new[]
			{
				new Modules.Purchases.BindingModels.OrderLine
				{
					ProductId = Guid.NewGuid(),
					Quantity = new Modules.Purchases.BindingModels.Quantity(10, "Nr"),
					Price = new Modules.Purchases.BindingModels.Price(10, "EUR")
				}
			}
		};
		var stringJson = JsonSerializer.Serialize(purchaseOrder);
		var httpContent = new StringContent(stringJson, Encoding.UTF8, "application/json");

		return await client.PostAsync(new Uri(_baseUri, "/v1/Purchases/Order"), httpContent);
	}
}