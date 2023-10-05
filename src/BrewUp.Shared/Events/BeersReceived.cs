using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Events;

namespace BrewUp.Shared.Events;

public class BeersReceived : IntegrationEvent
{
	public readonly PurchaseOrderId PurchaseOrderId;
	public readonly IEnumerable<OrderLine> OrderLines;

	public BeersReceived(PurchaseOrderId aggregateId, IEnumerable<OrderLine> orderLines) : base(aggregateId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}