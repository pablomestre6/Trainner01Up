using Project001.Domain.Entities;
using Project01.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Domain.Interfaces
{
    public interface IContatoRepository : IRepository<Contato, Guid>
    {
        Contato GetByEmail(string email);   
        Contato GetByPhone(Guid id);
        Contato GetPhone(Guid id);
    }
}
