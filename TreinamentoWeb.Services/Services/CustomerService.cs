using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Services.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<int> SaveCustomer(Customer customer)
        {
            ValidateCustomer(customer);
            return await _customerRepository.SaveCustomer(customer);
        }

        public IEnumerable<Customer> GetCustomers()
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
