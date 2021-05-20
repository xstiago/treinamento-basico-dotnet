using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Services.Helpers;

namespace TreinamentoWeb.Services.Validators
{
    public class NaturalPersonValidator : CustomerValidator<NaturalPerson>
    {
        public NaturalPersonValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CPF deve ser informada");
            RuleFor(x => x.CPF)
                .Must(x => DocumentCustomerHelper.ValidateCpf(x))
                .WithMessage("CPF inválido");
        }
    }
}
