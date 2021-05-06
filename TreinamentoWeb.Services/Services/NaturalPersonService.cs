using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Services.Services
{
    public class NaturalPersonService : BaseService<NaturalPerson>
    {
        public NaturalPersonService(IRepository<NaturalPerson> repository, IValidator<NaturalPerson> validator) : base(repository, validator)
        {
        }

    }
}
