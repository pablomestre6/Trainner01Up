using AutoMapper;
using MediatR;
using Projeto01.Application.Commands;
using Projeto01.Application.Interfaces;
using Projeto01.Application.Models;
using System;
using System.Threading.Tasks;

namespace Projeto01.Application.Services
{
    public class ContatoAppService : IContatoAppService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContatoAppService(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ContatoDto> Create(ContatoCreateCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = await _mediator.Send(command);

            return _mapper.Map<ContatoDto>(result);
        }

        public async Task<ContatoDto> Update(ContatoUpdateCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = await _mediator.Send(command);

            return _mapper.Map<ContatoDto>(result);
        }

        public async Task<ContatoDto> Delete(ContatoDeleteCommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var result = await _mediator.Send(command);

            return _mapper.Map<ContatoDto>(result);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
