using Projeto01.Application.Commands;
using Projeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Interfaces
{
    public interface IContatoAppService : IDisposable
    {
        Task<ContatoDto> Create(ContatoCreateCommand command);
        Task<ContatoDto> Update(ContatoUpdateCommand command);
        Task<ContatoDto> Delete(ContatoDeleteCommand command);
        
    }
}
