using AutoMapper;
using MediatR;
using Project001.Domain.Entities;
using Projeto01.Application.Commands;
using Projeto01.Application.Models;
using Projeto01.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.RequestHandlers
{
    public class ContatoRequestHandler : IDisposable,
        IRequestHandler<ContatoCreateCommand, ContatoDto>,
        IRequestHandler<ContatoUpdateCommand, ContatoDto>, 
        IRequestHandler<ContatoDeleteCommand, ContatoDto>
    {
        #region

        private readonly ContatoAppServices contatoAppServices;
        private readonly IMediator mediator;
        private IMapper _mapper;
     
        #endregion


        public async Task<ContatoDto> Handle(ContatoCreateCommand request,
            CancellationToken cancellationToken)
        {
            var contato = _mapper.Map<Contato>(request);

            if (!contato.Validate.IsValid)
                throw new Exception(contato.Validate.Errors);


            await _contatoDomainService.CreateAsync(contato);
            return _mapper.Map<ContatoDto>(contato);
        }
    }

}
