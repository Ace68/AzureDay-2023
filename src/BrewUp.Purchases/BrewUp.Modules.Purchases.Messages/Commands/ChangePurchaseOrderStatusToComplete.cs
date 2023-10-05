using BrewUp.Shared.DomainIds;
using Muflone.Messages.Commands;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public sealed class ChangePurchaseOrderStatusToComplete : Command
{
    public readonly PurchaseOrderId PurchaseOrderId;
    
    public ChangePurchaseOrderStatusToComplete(PurchaseOrderId aggregateId) : base(aggregateId)
    {
        PurchaseOrderId = aggregateId;
    }
}