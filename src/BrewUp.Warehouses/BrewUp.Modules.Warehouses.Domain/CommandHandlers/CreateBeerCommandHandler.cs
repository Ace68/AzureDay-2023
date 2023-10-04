using BrewUp.Shared.Abstracts;
using BrewUp.Shared.Commands;
using BrewUp.Shared.Events;
using MediatR;

namespace BrewUp.Modules.Warehouses.Domain.CommandHandlers;

public sealed class CreateBeerCommandHandler : CommandHandlerBase<CreateBeer>
{
	private readonly IPublisher _serviceBus;

	public CreateBeerCommandHandler(IPublisher serviceBus)
	{
		_serviceBus = serviceBus;
	}

	public override async Task Handle(CreateBeer command, CancellationToken cancellationToken)
	{
		var beerCreated = new BeerCreated(command.BeerId, command.BeerName);
		await _serviceBus.Publish(beerCreated, cancellationToken);
	}
}