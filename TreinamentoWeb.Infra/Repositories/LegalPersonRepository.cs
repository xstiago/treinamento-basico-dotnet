using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public class LegalPersonRepository
    {
        private readonly AppDbContext _context;

        public LegalPersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveCustomer(LegalPerson customer)
        {
            _context.LegalPerson.Add(customer);
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<LegalPerson> GetCustomers()
            => _context.LegalPerson.Where(w => w.Active);
    }
}
