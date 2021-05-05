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
        public NaturalPersonService(IRepository<NaturalPerson> repository) : base(repository)
        {
        }

        protected override void ValidateEntity(NaturalPerson entity)
        {
            var hasCpf = string.IsNullOrWhiteSpace(entity.CPF);
            var hasName = string.IsNullOrWhiteSpace(entity.Name);
            var hasEmail = string.IsNullOrWhiteSpace(entity.Email);
            var hasAddress = string.IsNullOrWhiteSpace(entity.Address);

            if (hasCpf || hasName || hasEmail || hasAddress)
                throw new ArgumentException("Cliente inválido");
        }
    }
}
