using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;

namespace TreinamentoWeb.Core.Interfaces
{
    public interface IService<TEntity>
        where TEntity : BaseEntity
    {
        Task<(int changedRecords, IEnumerable<string> errors)> Save(TEntity entity);
        IEnumerable<TEntity> Get();
    }
}
