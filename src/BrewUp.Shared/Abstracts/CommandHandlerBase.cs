using MediatR;

namespace BrewUp.Shared.Abstracts;

public abstract class CommandHandlerBase<T> : IRequestHandler<T> where T : Command
{
	public virtual Task Handle(T request, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}