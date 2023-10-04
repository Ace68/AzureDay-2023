using MediatR;

namespace BrewUp.Shared.Abstracts;

public record DomainEvent(DomainId AggregateId) : INotification;