using Microsoft.EntityFrameworkCore;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;
using TreinamentoWeb.Infra.Interfaces;

namespace TreinamentoWeb.Infra.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(IMongoContext context) : base(context)
        {
        }

    }
}
