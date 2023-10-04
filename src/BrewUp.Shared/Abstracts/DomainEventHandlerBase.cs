using MediatR;

namespace BrewUp.Shared.Abstracts;

public abstract class DomainEventHandlerBase<T> : INotificationHandler<T> where T : DomainEvent
{
	public virtual Task Handle(T notification, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}