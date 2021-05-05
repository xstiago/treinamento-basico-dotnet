using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public class NaturalPersonRepository : BaseRepository<NaturalPerson>
    {
        public NaturalPersonRepository(AppDbContext context) : base(context)
        {
        }

        protected override DbSet<NaturalPerson> GetContext()
        {
            return _context.NaturalPerson;
        }
    }
}
