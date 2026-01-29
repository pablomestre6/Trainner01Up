using AutoMapper;
using Project001.Domain.Entities;
using Projeto01.Application.Commands;
using Projeto01.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto01.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        public CommandToEntityMap()
        {
            CreateMap<ContatoCreateCommand, Contato>()
                .AfterMap((command, entity) =>
                {
                    entity.Id = Guid.NewGuid();
                    entity.CreatedAt = DateTime.Now;
                    entity.UpdatedAt = DateTime.Now;
                });

            CreateMap<ContatoCreateCommand, Contato>()
             .AfterMap((command, entity) =>
             {
                 entity.UpdatedAt = DateTime.Now;
             });
        }
    }
}
