using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Purchases.Messages.Events;

public sealed class PurchaseOrderStatusChangedToComplete : DomainEvent
{
    public readonly PurchaseOrderId PurchaseOrderId;
    public readonly IEnumerable<OrderLine> Lines;
    
    public PurchaseOrderStatusChangedToComplete(PurchaseOrderId aggregateId, IEnumerable<OrderLine> lines) : base(aggregateId)
    {
        PurchaseOrderId = aggregateId;
        Lines = lines;
    }
}