using FluentValidation;
using System.Linq;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Services.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.Customer)
                .NotEmpty()
                .WithMessage("Deve ser informado o cliente.");

            RuleFor(o => o.Products)
                .NotEmpty()
                .WithMessage("Deve ser informado ao menos um produto.");

            RuleFor(o => o.Products)
                .Must(products =>
                {
                    var distinctList = products.Distinct();

                    return distinctList.Count() == products.Count();
                })
                .WithMessage("Os produtos não podem ");
        }
    }
}
