using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public sealed record CreatePurchaseOrder(PurchaseOrderId PurchaseOrderId,
	SupplierId SupplierId,
	DateTime Date,
	IEnumerable<OrderLine> Lines) : Command(PurchaseOrderId);