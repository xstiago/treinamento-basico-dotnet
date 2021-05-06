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
    public class LegalPersonValidator : CustomerValidator<LegalPerson>
    {
        public LegalPersonValidator()
        {           
            RuleFor(x => x.CNPJ)
                .NotNull()
                .NotEmpty()
                .WithMessage("O CNPJ deve ser informado");            
            RuleFor(x => x.CNPJ)
                .Must(x => DocumentCustomerHelper.ValidateCnpj(x))
                .WithMessage("CNPJ inválido");
        }
    }
}
