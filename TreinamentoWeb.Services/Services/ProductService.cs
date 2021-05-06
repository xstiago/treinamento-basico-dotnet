using FluentValidation;
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
        public ProductService(IRepository<Product> repository, IValidator<Product> validator) : base(repository, validator)
        {
        }
    }
}
