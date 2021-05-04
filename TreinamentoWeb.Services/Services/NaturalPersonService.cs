using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Services.Services
{
    public class NaturalPersonService
    {
        private readonly NaturalPersonRepository _customerRepository;

        public NaturalPersonService(NaturalPersonRepository customerRepository)
        {
            _customerRepository = customerRepository;
        } 

        public async Task<int> SaveCustomer(NaturalPerson customer)
        {
            ValidateCustomer(customer);
            return await _customerRepository.SaveCustomer(customer);
        }

        public IEnumerable<NaturalPerson> GetCustomers()
            => _customerRepository.GetCustomers();

        #region Private Methods
        private void ValidateCustomer(NaturalPerson customer)
        {
            var hasCpf = string.IsNullOrWhiteSpace(customer.CPF);
            var hasName = string.IsNullOrWhiteSpace(customer.Name);
            var hasEmail = string.IsNullOrWhiteSpace(customer.Email);
            var hasAddress = string.IsNullOrWhiteSpace(customer.Address);
           
            if (hasCpf || hasName || hasEmail || hasAddress)
                throw new ArgumentException("Cliente inválido");


        }
        #endregion
    }
}
