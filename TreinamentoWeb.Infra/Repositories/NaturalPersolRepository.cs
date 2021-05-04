using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public class NaturalPersonRepository
    {
        private readonly AppDbContext _context;

        public NaturalPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveCustomer(NaturalPerson customer)
        {
            _context.NaturalPerson.Add(customer);
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<NaturalPerson> GetCustomers()
            => _context.NaturalPerson.Where(w => w.Active);
    }
}
