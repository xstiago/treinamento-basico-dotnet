using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Services.Services
{
    public class LegalPersonService : BaseService<LegalPerson>
    {
        public LegalPersonService(IRepository<LegalPerson> repository, IValidator<LegalPerson> validator) : base(repository, validator)
        {
        }
    }
}
