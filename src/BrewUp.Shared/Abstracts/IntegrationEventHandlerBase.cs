using MediatR;

namespace BrewUp.Shared.Abstracts;

public abstract class IntegrationEventHandlerBase<T> : INotificationHandler<T> where T : IntegrationEvent
{
	public virtual Task Handle(T notification, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}