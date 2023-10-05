using BrewUp.Modules.Purchases.SharedKernel.DomainIds;
using BrewUp.Modules.Purchases.SharedKernel.Dtos;
using BrewUp.Shared.Abstracts;
using BrewUp.Shared.DomainIds;
using BrewUp.Shared.Dtos;

namespace BrewUp.Modules.Purchases.ReadModel.Entities;

public class PurchaseOrder : EntityBase
{
	public DateTime Date { get; private set; }
	public IEnumerable<OrderLine> Lines { get; private set; }
	public SupplierId SupplierId { get; private set; }
	public Status Status { get; set; }

	public static PurchaseOrder Create(PurchaseOrderId purchaseOrderId, DateTime date, IEnumerable<OrderLine> lines,
		SupplierId supplierId)
	{
		return new PurchaseOrder(purchaseOrderId, date, lines, supplierId);
	}

	private PurchaseOrder(PurchaseOrderId purchaseOrderId, DateTime date, IEnumerable<OrderLine> lines,
		SupplierId supplierId)
	{
		Date = date;
		Lines = lines;
		SupplierId = supplierId;
		Status = Status.Created;
	}
}