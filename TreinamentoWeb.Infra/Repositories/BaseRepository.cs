using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected abstract DbSet<TEntity> GetContext();

        public async Task<int> SaveCustomer(TEntity customer)
        {
            GetContext().Add(customer);
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetCustomers()
            => GetContext().Where(w => w.Active);
    }
}
