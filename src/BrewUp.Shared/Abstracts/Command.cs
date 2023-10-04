using MediatR;

namespace BrewUp.Shared.Abstracts;

public record Command(DomainId AggregateId) : IRequest;