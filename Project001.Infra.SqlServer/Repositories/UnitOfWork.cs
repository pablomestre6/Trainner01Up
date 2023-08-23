using Microsoft.EntityFrameworkCore.Storage;
using Project001.Domain.Interfaces;
using Project001.Infra.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Infra.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext _sqlServerContext;
       

        public UnitOfWork(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public IContatoRepository ContatoRepositoy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public object ContatoRepository => throw new NotImplementedException();

        private IDbContextTransaction _dbContextTransaction;

        public void BeginTransation()
        {
            _dbContextTransaction = _sqlServerContext
                                        .Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public void RollBackTransation()
        {
            _dbContextTransaction.Rollback();
        }


        public void Dispose()
        {
            _sqlServerContext.Dispose();
        }
    }
}
