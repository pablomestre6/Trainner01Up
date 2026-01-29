using Microsoft.EntityFrameworkCore;
using Project001.Domain.Entities;
using Project001.Infra.MySql.Configurations;


namespace Project001.Infra.MySql.Contexts
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        public DbSet<Contato> Contatos => Set<Contato>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
