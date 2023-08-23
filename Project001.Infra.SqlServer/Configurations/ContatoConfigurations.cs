using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project001.Domain.Entities;
using Project01.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Infra.SqlServer.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder) 
        {
            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasIndex(c => c.Phone).IsUnique();
        }
    }
}
