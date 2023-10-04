using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;

namespace BrewUp.Modules.Purchases.Messages.Commands;

public sealed record ChangePurchaseOrderStatusToComplete(PurchaseOrderId PurchaseOrderId) : Command(PurchaseOrderId);