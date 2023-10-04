using MediatR;

namespace BrewUp.Shared.Abstracts;

public record IntegrationEvent(DomainId AggregateId) : INotification;