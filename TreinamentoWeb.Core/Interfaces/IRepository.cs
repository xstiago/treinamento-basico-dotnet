using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity:BaseEntity
    {
        IEnumerable<TEntity> GetCustomers();

        Task<int> SaveCustomer(TEntity customer);
    }
}
