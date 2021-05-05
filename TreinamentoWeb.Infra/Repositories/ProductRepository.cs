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
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        protected override DbSet<Product> GetContext()
        {
            return _context.Product;
        }
    }
}
