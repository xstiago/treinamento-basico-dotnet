using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;

namespace TreinamentoWeb.Services.Services
{
    public class ProductService :  BaseService<Product>
    {
        public ProductService(IRepository<Product> repository) : base(repository)
        {
        }

        protected override void ValidateEntity(Product entity)
        {
            var hasDescription = string.IsNullOrWhiteSpace(entity.Description);
            var hasKind = string.IsNullOrWhiteSpace(entity.Kind);
            var hasManufacturer = string.IsNullOrWhiteSpace(entity.Manufacturer);
            var hasPrice = entity.Price <= 0;

            if (hasDescription || hasKind || hasManufacturer || hasPrice)
                throw new ArgumentException("Produto inválido");
        }
    }
}
