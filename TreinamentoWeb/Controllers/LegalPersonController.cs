using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Services.Services;

namespace TreinamentoWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalPersonController : ControllerBase
    {
        private readonly IService<LegalPerson> _customerService;

        public LegalPersonController(IService<LegalPerson> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<LegalPerson> GetAll()
        {
            return _customerService.Get();
        }

        [HttpPost]
        public async Task<string> Post([FromBody] LegalPerson customer)
        {
            int countCustomerInserted = await _customerService.Save(customer);
            if (countCustomerInserted == 1)
                return "Cliente inserido com sucesso!";
            else
                return "Ocorreu um erro ao inserir o cliente";
        }
    }
}
