using BrewUp.Shared.Abstracts;

namespace BrewUp.Shared.DomainIds;

public record BeerId(Guid Value) : DomainId(Value);