using BrewUp.Modules.Purchases.BindingModels;
using FluentValidation;

namespace BrewUp.Modules.Purchases.Validators;

public sealed class OrderValidator : AbstractValidator<Order>
{
	public OrderValidator()
	{
		RuleFor(v => v.SupplierId).NotEqual(Guid.Empty);
		RuleFor(v => v.Date).GreaterThan(DateTime.MinValue);

		RuleForEach(v => v.Lines).SetValidator(new OrderLineValidator());
	}
}