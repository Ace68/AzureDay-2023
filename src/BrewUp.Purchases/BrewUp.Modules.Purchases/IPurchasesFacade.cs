namespace BrewUp.Modules.Purchases;

public interface IPurchasesFacade
{
	Task<string> CreateOrderAsync(BindingModels.Order order, CancellationToken cancellationToken);
	Task ChangeStatusToComplete(Guid id, CancellationToken cancellationToken);
	Task<IEnumerable<BindingModels.Order>> GetPurchasesOrdersAsync(CancellationToken cancellationToken);
}