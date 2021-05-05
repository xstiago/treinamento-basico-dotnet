using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public class LegalPersonRepository : BaseRepository<LegalPerson>
    {
        public LegalPersonRepository(AppDbContext context) : base(context)
        {
        }

        protected override DbSet<LegalPerson> GetContext()
        {
            return _context.LegalPerson;
        }
    }
}
