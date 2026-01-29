using MediatR;
using Projeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Commands
{
    public class ContatoCreateCommand : IRequest<ContatoDto>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }

        public string? Telefone { get; set; }
    }
}
