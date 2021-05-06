using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Core.Interfaces;
using TreinamentoWeb.Services.Services;

namespace TreinamentoWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _productService;

        public ProductController(IService<Product> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.Get();
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Product product)
        {
            (int changedRecords, IEnumerable<string> errors) = await _productService.Save(product);
            if (changedRecords == 1)
                return "Produto inserido com sucesso!";
            else
                return $"Ocorreu um erro ao inserir o produto {Environment.NewLine} {string.Join(Environment.NewLine, errors)}";
        }
    }
}
