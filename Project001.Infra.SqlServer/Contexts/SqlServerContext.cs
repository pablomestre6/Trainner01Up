using Microsoft.EntityFrameworkCore;
using Project001.Domain.Entities;
using Project001.Infra.SqlServer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Infra.SqlServer.Contexts
{
    public class SqlServerContext : DbContext
    {
        protected override void OnConfiguring
                                      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BDProjeto01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
        }

        public DbSet<Contato>? Contatos { get; set; }
    }
}
