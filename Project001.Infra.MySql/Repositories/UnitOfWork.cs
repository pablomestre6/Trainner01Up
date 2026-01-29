using Project001.Domain.Interfaces;
using Project001.Infra.MySql.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Project001.Infra.MySql.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext _context;
        private IDbContextTransaction? _transaction;

        public IContatoRepository ContatoRepository { get; }

        public UnitOfWork(MySqlContext context)
        {
            _context = context;
            ContatoRepository = new ContatoRepository(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
                await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
