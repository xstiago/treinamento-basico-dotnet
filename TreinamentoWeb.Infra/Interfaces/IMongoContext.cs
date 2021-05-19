using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace TreinamentoWeb.Infra.Interfaces
{
    public interface IMongoContext : IDisposable
    {
        void AddCommand(Func<Task> func);
        IMongoCollection<T> GetCollection<T>(string name);
        Task<int> SaveChangesAsync();
    }
}
