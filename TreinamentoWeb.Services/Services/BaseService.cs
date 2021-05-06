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
    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : BaseEntity        
    {
        private readonly IRepository<TEntity> repository;
        private readonly IValidator<TEntity> validator;

        protected BaseService(IRepository<TEntity> repository, IValidator<TEntity> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task<(int changedRecords, IEnumerable<string> errors)> Save(TEntity entity)
        {
            (bool isValid, IEnumerable<string> errors) = ValidateEntity(entity);

            if (isValid)
                return (await repository.Save(entity), null);

            return (-1, errors);
        }

        public IEnumerable<TEntity> Get()
            => repository.Get();

        private (bool isValid, IEnumerable<string> errors) ValidateEntity(TEntity entity)
        {
            var validationResult = validator.Validate(entity);
            return (validationResult.IsValid, validationResult.Errors.Select(o => o.ErrorMessage));
        }
    }
}
