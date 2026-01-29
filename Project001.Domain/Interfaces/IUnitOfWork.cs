using System;
using System.Threading.Tasks;

namespace Project001.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IContatoRepository ContatoRepository { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
