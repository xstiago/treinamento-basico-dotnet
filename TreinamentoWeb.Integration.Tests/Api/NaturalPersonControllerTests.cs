﻿using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TreinamentoWeb.Api;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Integration.Tests.Fixture;
using Xunit;

namespace TreinamentoWeb.Integration.Tests.Api
{
    [Collection("Startup")]
    public class NaturalPersonControllerTests : IClassFixture<WebApplicationFactory<Startup>>, IDisposable
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly MongoDbFixture _dbFixture;

        public NaturalPersonControllerTests(WebApplicationFactory<Startup> factory)
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

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "54822590054",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            #endregion Arrange

            #region Act

            var responseMessage = await client.PostAsJsonAsync("api/NaturalPerson/", payload);

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            Assert.Equal("Cliente inserido com sucesso!", result);

            #endregion Assert
        }

        [Fact]
        public async Task Should_Not_Save_Natural_Person_On_Repository_When_Receive_Invalid_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "54822590999",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            #endregion Arrange

            #region Act

            var responseMessage = await client.PostAsJsonAsync("api/NaturalPerson/", payload);

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var result = await responseMessage.Content.ReadAsStringAsync();

            Assert.NotEqual("Cliente inserido com sucesso!", result);

            #endregion Assert
        }

        [Fact]
        public async Task Should_Get_Natural_Person_From_Repository_When_There_Are_Data()
        {
            #region Arrange

            var client = _factory.CreateClient();

            var payload = new NaturalPerson
            {
                Active = true,
                Address = "Rua XXX",
                CPF = "77522810000",
                Email = "fulano@terra.com.br",
                Name = "Fulano da Silva"
            };

            await _dbFixture.AddSync(payload);

            #endregion Arrange

            #region Act

            var responseMessage = await client.GetAsync("api/NaturalPerson/");

            #endregion Act

            #region Assert

            responseMessage.EnsureSuccessStatusCode();

            var jsonResult = await responseMessage.Content.ReadAsStringAsync();

            var naturalPersonList = JsonSerializer.Deserialize<IEnumerable<NaturalPerson>>(jsonResult, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Assert.NotEmpty(naturalPersonList);
            Assert.Contains(naturalPersonList, o => o.CPF == payload.CPF);

            #endregion Assert
        }
    }
}
