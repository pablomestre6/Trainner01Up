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
    public class EntityModelMap : Profile
    {
        public EntityModelMap() 
        {
            CreateMap<ContatoDto, Contato>();
        }
    }
}
