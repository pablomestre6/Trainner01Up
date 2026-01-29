using MediatR;
using Projeto01.Application.Commands;
using Projeto01.Application.Interfaces;
using Projeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Services
{
    public class ContatoAppServices : IContatoAppService
    {
        private readonly IMediator _mediator;

        public ContatoAppServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ContatoDto> Create(ContatoCreateCommand command) => await _mediator.Send(command);

        public async Task<ContatoDto> Delete(ContatoDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ContatoDto> Update(ContatoUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
