using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Services.Services
{
    public class LegalPersonService
    {
        private readonly LegalPersonRepository _customerRepository;

        public LegalPersonService(LegalPersonRepository customerRepository)
        {
            _customerRepository = customerRepository;
        } 

        public async Task<int> SaveCustomer(LegalPerson customer)
        {
            ValidateCustomer(customer);
            return await _customerRepository.SaveCustomer(customer);
        }

        public IEnumerable<LegalPerson> GetCustomers()
            => _customerRepository.GetCustomers();

        #region Private Methods
        private void ValidateCustomer(LegalPerson customer)
        {
            var hasCnpj = string.IsNullOrWhiteSpace(customer.CNPJ);
            var hasName = string.IsNullOrWhiteSpace(customer.Name);
            var hasEmail = string.IsNullOrWhiteSpace(customer.Email);
            var hasAddress = string.IsNullOrWhiteSpace(customer.Address);
           
            if (hasCnpj || hasName || hasEmail || hasAddress)
                throw new ArgumentException("Cliente inválido");


        }
        #endregion
    }
}
