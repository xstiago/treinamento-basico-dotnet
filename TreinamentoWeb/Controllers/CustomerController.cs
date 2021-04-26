using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Services.Services;

namespace TreinamentoWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> GetAll()
        {
            return _customerService.GetCustomers();
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Customer customer)
        {
            int countCustomerInserted = await _customerService.SaveCustomer(customer);
            if (countCustomerInserted == 1)
                return "Cliente inserido com sucesso!";
            else
                return "Ocorreu um erro ao inserir o cliente";
        }
    }
}
