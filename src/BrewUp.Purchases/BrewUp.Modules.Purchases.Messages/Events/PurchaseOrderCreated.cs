using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.Messages.Events;

public sealed record PurchaseOrderCreated(PurchaseOrderId PurchaseOrderId,
	SupplierId SupplierId,
	DateTime Date,
	IEnumerable<OrderLine> Lines) : DomainEvent(PurchaseOrderId);