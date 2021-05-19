using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;
using TreinamentoWeb.Infra.Interfaces;

namespace TreinamentoWeb.Infra.Repositories
{
    public class LegalPersonRepository : BaseRepository<LegalPerson>
    {
        public LegalPersonRepository(IMongoContext context) : base(context)
        {
        }

    }
}
