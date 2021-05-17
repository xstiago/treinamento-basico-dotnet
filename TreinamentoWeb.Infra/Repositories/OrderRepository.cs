using Microsoft.EntityFrameworkCore;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;

namespace TreinamentoWeb.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        protected override DbSet<Order> GetContext()
        {
            return _context.Order;
        }
    }
}
