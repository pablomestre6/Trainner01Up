using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransation();
        void CommitTransaction();
        void RollBackTransation();

        #region Repoaitórios

        public IContatoRepository ContatoRepositoy { get; set; }
        object ContatoRepository { get; }

        #endregion
    }
}
