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
        public LegalPersonService(IRepository<LegalPerson> repository) : base(repository)
        {
        }

        protected override void ValidateEntity(LegalPerson entity)
        {
            var hasCnpj = string.IsNullOrWhiteSpace(entity.CNPJ);
            var hasName = string.IsNullOrWhiteSpace(entity.Name);
            var hasEmail = string.IsNullOrWhiteSpace(entity.Email);
            var hasAddress = string.IsNullOrWhiteSpace(entity.Address);

            if (hasCnpj || hasName || hasEmail || hasAddress)
                throw new ArgumentException("Cliente inválido");
            throw new NotImplementedException();
        }
    }
}
