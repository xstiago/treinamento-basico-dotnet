using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Infra.Interfaces;

namespace TreinamentoWeb.Infra.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IMongoContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
            _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public async Task<int> Save(TEntity entity)
        {
            _context.AddCommand(() => _collection.InsertOneAsync(entity));
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Get()
        {
            var filter = Builders<TEntity>.Filter.Empty;
            var data = _collection.Find(filter);
            return data.ToList();

        }
            
    }
}
