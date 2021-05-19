using System.Threading.Tasks;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Infra.Interfaces;

namespace TreinamentoWeb.Infra.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;

        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            var changeAmount = await _context.SaveChangesAsync();
            return changeAmount > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
