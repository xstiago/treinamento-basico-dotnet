using FluentValidation;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;

namespace TreinamentoWeb.Services.Services
{
    public class OrderService : BaseService<Order>
    {
        public OrderService(IRepository<Order> repository, IValidator<Order> validator) 
            : base(repository, validator)
        {
        }
    }
}
