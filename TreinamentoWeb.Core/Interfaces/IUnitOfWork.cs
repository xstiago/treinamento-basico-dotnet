using System;
using System.Threading.Tasks;

namespace TreinamentoWeb.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
