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
    public class NaturalPersonValidator : AbstractValidator<NaturalPerson>
    {
        public NaturalPersonValidator()
        {
           
            RuleFor(x => x.CPF)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CPF deve ser informada");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome deve ser informado");

            RuleFor(x => x.Address)
                .NotNull()
                .NotEmpty()
                .WithMessage("O endereço deve ser informado");

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("O e-mail deve ser informado");

            RuleFor(x => x.CPF)
                .Must(x => DocumentCustomerHelper.ValidateCpf(x))
                .WithMessage("CPF inválido");

        }
    }
}
