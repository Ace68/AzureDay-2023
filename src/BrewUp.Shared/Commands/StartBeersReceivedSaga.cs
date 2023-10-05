using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;
using Muflone.Messages.Commands;

namespace BrewUp.Shared.Commands;

public class StartBeersReceivedSaga : Command
{
	public readonly PurchaseOrderId PurchaseOrderId;

	public readonly IEnumerable<OrderLine> OrderLines;

	public StartBeersReceivedSaga(PurchaseOrderId aggregateId, IEnumerable<OrderLine> orderLines)
		: base(aggregateId)
	{
		PurchaseOrderId = aggregateId;
		OrderLines = orderLines;
	}
}