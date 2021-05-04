using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Services.Services
{
    public class NaturalPersonService
    {
        private readonly CustomerRepository _customerRepository;

        public NaturalPersonService(CustomerRepository customerRepository)
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
        private void ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name) || string.IsNullOrWhiteSpace(customer.Email) || string.IsNullOrWhiteSpace(customer.Address))
                throw new ArgumentException("Cliente inválido");
        }
        #endregion
    }
}
