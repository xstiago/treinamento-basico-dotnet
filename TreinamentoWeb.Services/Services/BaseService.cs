using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;

namespace TreinamentoWeb.Services.Services
{
    public abstract class BaseService<TEntity> 
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> repository;

        protected BaseService(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public async Task<int> Save(TEntity entity)
        {
            ValidateEntity(entity);
            return await repository.Save(entity);
        }

        public IEnumerable<TEntity> Get()
            => repository.Get();

        #region Private Methods
        protected abstract void ValidateEntity(TEntity entity);
        #endregion
    }
}
