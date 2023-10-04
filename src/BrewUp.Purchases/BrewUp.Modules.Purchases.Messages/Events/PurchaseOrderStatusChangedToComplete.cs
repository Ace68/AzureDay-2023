using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.Messages.Events;

public sealed record PurchaseOrderStatusChangedToComplete(PurchaseOrderId PurchaseOrderId,
	IEnumerable<OrderLine> Lines) : DomainEvent(PurchaseOrderId);