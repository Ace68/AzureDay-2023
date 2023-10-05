using BrewUp.Modules.Purchases.Domain.Helpers;
using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Core;

namespace BrewUp.Modules.Purchases.Domain.Entities;

public class PurchaseOrder : AggregateRoot
{
    private PurchaseOrderId _purchaseOrderId = default!;
    private SupplierId _supplierId = default!;
    private DateTime _date = default!;
    private IEnumerable<PurchaseLine> _lines = default!;

    protected PurchaseOrder()
    {
    }
    
    internal static PurchaseOrder CreatePurchaseOrder(PurchaseOrderId purchaseOrderId, SupplierId supplierId, DateTime date, IEnumerable<OrderLine> lines)
    {
        return new PurchaseOrder(purchaseOrderId, supplierId, date, lines);
    }

    private PurchaseOrder (PurchaseOrderId purchaseOrderId,
        SupplierId supplierId, DateTime date, IEnumerable<OrderLine> lines)
    {
        RaiseEvent(new PurchaseOrderCreated(purchaseOrderId, supplierId, date, lines));
    }

    private void Apply(PurchaseOrderCreated @event)
    {
        Id = @event.PurchaseOrderId;
        _purchaseOrderId = @event.PurchaseOrderId;
        _supplierId = @event.SupplierId;
        _date = @event.Date;
        _lines = @event.Lines.ToDomainEntities();
    }

    internal void ChangePurchaseOrderStatusToComplete(PurchaseOrderId purchaseOrderId)
    {
        RaiseEvent(new PurchaseOrderStatusChangedToComplete(purchaseOrderId, _lines.ToDtos()));
    }
    
    private void Apply(PurchaseOrderStatusChangedToComplete @event)
    {
        _lines = @event.Lines.ToDomainEntities();
    }
}