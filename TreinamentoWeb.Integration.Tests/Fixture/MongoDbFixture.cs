using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using TreinamentoWeb.Core.Entities;
using TreinamentoWeb.Infra.Context;
using TreinamentoWeb.Infra.Repositories;

namespace TreinamentoWeb.Integration.Tests.Fixture
{
    public class MongoDbFixture : IDisposable
    {
        private readonly string _connectionString;

        public MongoContext DbContext { get; private set; }

        public MongoDbFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = config["MongoDb:ConnectionString"];

            DbContext = new MongoContext(config);
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
                var client = new MongoClient(_connectionString);
                var dbName = MongoUrl.Create(_connectionString).DatabaseName;
                client.DropDatabase(dbName);

                DbContext.Dispose();
            }
        }

        public async Task AddSync(NaturalPerson entity)
        {
            var repository = new NaturalPersonRepository(DbContext);

            await repository.Save(entity);
        }

        public async Task AddSync(LegalPerson entity)
        {
            var repository = new LegalPersonRepository(DbContext);

            await repository.Save(entity);
        }
    }
}
