using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;
using TreinamentoWeb.Infra.Interfaces;

namespace TreinamentoWeb.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(IMongoContext context) : base(context)
        {
        }

    }
}
