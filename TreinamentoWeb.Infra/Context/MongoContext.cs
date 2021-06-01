using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Infra.Interfaces;

namespace TreinamentoWeb.Infra.Context
{
    [ExcludeFromCodeCoverage]
    public class MongoContext : IMongoContext
    {
        private readonly ICollection<Func<Task>> _commands;
        private readonly string _mongoConncetionString;
        private IMongoClient mongoClient;
        private IMongoDatabase mongoDatabase;
        private IClientSessionHandle sessionHandle;

        private void ConfigureMongo()
        {
            if (mongoClient != null)
            {
                return;
            }

            mongoClient = new MongoClient(_mongoConncetionString);

            var dbName = MongoUrl.Create(_mongoConncetionString).DatabaseName;
            mongoDatabase = mongoClient.GetDatabase(dbName);
        }

        public MongoContext(IConfiguration configuration)
        {
            _mongoConncetionString = configuration.GetSection("MongoDb:ConnectionString").Value;
            _commands = new List<Func<Task>>();
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public void Dispose()
        {
            sessionHandle?.Dispose();
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return mongoDatabase.GetCollection<T>(name);
        }

        public async Task<int> SaveChangesAsync()
        {
            if (!_commands.Any())
            {
                return 0;
            }

            ConfigureMongo();

            using (sessionHandle = await mongoClient.StartSessionAsync())
            {
                var commandTasks = _commands.Select(c => c());

                await Task.WhenAll(commandTasks);
            }

            var affectedRows = _commands.Count;
            
            _commands.Clear();

            return affectedRows;
        }
    }
}
