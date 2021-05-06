using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Services.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("A descrição deve ser informada");

            RuleFor(x => x.Kind)
                .NotNull()
                .NotEmpty()
                .WithMessage("O tipo deve ser informado");
            
            RuleFor(x => x.Manufacturer)
                .NotNull()
                .NotEmpty()
                .WithMessage("O fabricante deve ser informado");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("O preço deve ser maior que zeros");

        }
    }
}
