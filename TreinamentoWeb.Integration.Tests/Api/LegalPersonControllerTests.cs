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
    public class LegalPersonControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly MongoDbFixture _dbFixture;

        public LegalPersonControllerTests(WebApplicationFactory<Startup> factory)
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
        public async Task Should_Save_Natural_Person_On_Repository_When_Receive_Valid_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new LegalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CNPJ = "96764618000105",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            #endregion Arrange

            #region Act

            var responseMessage = await client.PostAsJsonAsync("api/LegalPerson/", payload);

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            Assert.Equal("Cliente inserido com sucesso!", result);

            #endregion Assert
        }

        [Fact]
        public async Task Should_Get_Natural_Person_From_Repository_When_There_Are_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new LegalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CNPJ = "96874672000103",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            await _dbFixture.AddSync(payload);

            #endregion Arrange

            #region Act

            var responseMessage = await client.GetAsync("api/LegalPerson/");

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var jsonResult = await responseMessage.Content.ReadAsStringAsync();

            var legalPersonList = JsonSerializer.Deserialize<IEnumerable<LegalPerson>>(jsonResult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotEmpty(legalPersonList);
            Assert.Contains(legalPersonList, o => o.CNPJ == payload.CNPJ);

            #endregion Assert
        }

    }
}
