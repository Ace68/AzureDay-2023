using BrewUp.Shared.Abstracts;

namespace BrewUp.Shared.DomainIds;

public record PurchaseOrderId(Guid Value) : DomainId(Value);