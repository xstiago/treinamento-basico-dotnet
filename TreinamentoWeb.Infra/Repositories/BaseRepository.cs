using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        protected BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected abstract DbSet<TEntity> GetContext();

        public async Task<int> Save(TEntity entity)
        {
            GetContext().Add(entity);
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Get()
            => GetContext().Where(w => w.Active);
    }
}
