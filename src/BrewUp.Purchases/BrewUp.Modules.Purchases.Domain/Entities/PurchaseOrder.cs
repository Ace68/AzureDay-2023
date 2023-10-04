using BrewUp.Modules.Purchases.Messages.Events;
using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.Domain.Entities;

public class PurchaseOrder : AggregateRoot
{
    private PurchaseOrderId _purchaseOrderId;
    private SupplierId _supplierId;
    private DateTime _date;
    private IEnumerable<PurchaseLine> _lines;

    protected PurchaseOrder()
    {
        _purchaseOrderId = default!;
        _supplierId = default!;
        _date = default!;
        _lines = default!;
    }

    internal static PurchaseOrderCreated RaisePurchaseOrderCreated(PurchaseOrderId purchaseOrderId,
        SupplierId supplierId, DateTime date, IEnumerable<OrderLine> lines)
    {
        return new PurchaseOrderCreated(purchaseOrderId, supplierId, date, lines);
    }

    private void Apply(PurchaseOrderCreated @event)
    {
        _purchaseOrderId = @event.PurchaseOrderId;
        _supplierId = @event.SupplierId;
        _date = @event.Date;
        _lines = @event.Lines.Select(l => PurchaseLine.CreatePurchaseLine(l.BeerId, l.BeerName, l.Quantity, l.Price));
    }

    internal static PurchaseOrderStatusChangedToComplete ChangePurchaseOrderStatusToComplete(PurchaseOrderId purchaseOrderId)
    {
        var lines = Enumerable.Empty<OrderLine>();
        lines = lines.Concat(new List<OrderLine>
        {
            new ()
            {
                BeerId = new BeerId(Guid.NewGuid()),
                BeerName = new BeerName("Muflone IPA"),
                Quantity = new Quantity()
                {
                    Value = 10,
                    UnitOfMeasure = "NR"
                },
                Price = new Price()
                {
                    Value = 2.5m,
                    Currency = "EUR"
                },
            },
        });
        
        return new PurchaseOrderStatusChangedToComplete(purchaseOrderId, lines);
    }
}