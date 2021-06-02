using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TreinamentoWeb.Api;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Integration.Tests.Fixture;
using Xunit;

namespace TreinamentoWeb.Integration.Tests.Api
{
    [Collection("Startup")]
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly MongoDbFixture _dbFixture;

        public ProductControllerTests(WebApplicationFactory<Startup> factory)
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
        public async Task Should_Save_Product_On_Repository_When_Receive_Valid_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new Product
            {
                Active = true,
                Description = "Teste",
                Kind = "Teste_Kind",
                Manufacturer = "Teste_Manufacturer",
                Price = 1

            };

            #endregion Arrange

            #region Act

            var responseMessage = await client.PostAsJsonAsync("api/Product/", payload);

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            Assert.Equal("Produto inserido com sucesso!", result);

            #endregion Assert
        }

        [Fact]
        public async Task Should_Not_Save_Product_On_Repository_When_Receive_Invalid_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new Product
            {
                Active = true,
                Description = "Teste",
                Kind = "Teste_Kind",
                Manufacturer = "Teste_Manufacturer",
                Price = 1
            };

            #endregion Arrange

            #region Act

            var responseMessage = await client.PostAsJsonAsync("api/Product/", payload);

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            Assert.NotEqual("Cliente inserido com sucesso!", result);

            #endregion Assert
        }

        [Fact]
        public async Task Should_Get_Product_From_Repository_When_There_Are_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new Product
            {
                Active = true,
                Description = "Teste",
                Kind = "Teste_Kind",
                Manufacturer = "Teste_Manufacturer",
                Price = 1
            };

            await _dbFixture.AddSync(payload);

            #endregion Arrange

            #region Act

            var responseMessage = await client.GetAsync("api/Product/");

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var jsonResult = await responseMessage.Content.ReadAsStringAsync();

            var ProductList = JsonSerializer.Deserialize<IEnumerable<Product>>(jsonResult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotEmpty(ProductList);
            Assert.Contains(ProductList, o => o.Description == payload.Description);

            #endregion Assert
        }


    }
}
