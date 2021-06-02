using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TreinamentoWeb.Api;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Integration.Tests.Fixture;
using Xunit;

namespace TreinamentoWeb.Integration.Tests.Api
{
    public class OrderControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly MongoDbFixture _dbFixture;

        public OrderControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _dbFixture = new MongoDbFixture();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbFixture?.Dispose();
            }
        }

        [Fact]
        public async Task Should_Save_Order_On_Repository_When_Receive_Valid_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var productPayload = new Product
            {
                Active = true,
                Description = "Teste",
                Kind = "Teste_Kind",
                Manufacturer = "Teste_Manufacturer",
                Price = 1

            };

            var customerPayload = new LegalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CNPJ = "96764618000105",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            var orderPayLoad = new Order
            {
                Customer = customerPayload,
                Products = new List<Product>() { productPayload },
                Active = true,
                RequestDate = DateTime.Now
            };

            #endregion Arrange

            #region Act

            var responseMessage = await client.PostAsJsonAsync("api/Order/", orderPayLoad);

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            Assert.Equal("Pedido inserido com sucesso!", result);

            #endregion Assert
        }

    }
}
