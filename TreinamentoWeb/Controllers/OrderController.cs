using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;

namespace TreinamentoWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService<Order> _orderService;

        public OrderController(IService<Order> customerService)
        {
            _orderService = customerService;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _orderService.Get();
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Order customer)
        {
            (int changedRecords, IEnumerable<string> errors) = await _orderService.Save(customer);
            if (changedRecords == 1)
                return "Pedido inserido com sucesso!";
            else
                return $"Ocorreu um erro ao inserir o pedido {Environment.NewLine} {string.Join(Environment.NewLine, errors)}";
        }
    }
}
