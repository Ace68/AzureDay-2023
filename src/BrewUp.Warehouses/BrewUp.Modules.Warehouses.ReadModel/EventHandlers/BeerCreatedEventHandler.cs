using BrewUp.Shared.Events;
using Microsoft.Extensions.Logging;
using Muflone.Messages.Events;

namespace BrewUp.Modules.Warehouses.ReadModel.EventHandlers;

public class BeerCreatedEventHandler : DomainEventHandlerAsync<BeerCreated>
{
	public BeerCreatedEventHandler(ILoggerFactory loggerFactory) : base(loggerFactory)
	{
	}

	public override Task HandleAsync(BeerCreated @event, CancellationToken cancellationToken = new ())
	{
		// Update ReadModel
		return Task.CompletedTask;
	}
}