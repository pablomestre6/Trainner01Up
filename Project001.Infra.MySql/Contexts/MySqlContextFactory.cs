using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project001.Infra.MySql.Contexts
{
    public class MySqlContextFactory 
        : IDesignTimeDbContextFactory<MySqlContext>
    {
        public MySqlContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySqlContext>();

            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=bdprojeto01;user=root;password=;",
                ServerVersion.AutoDetect(
                    "server=localhost;port=3306;database=bdprojeto01;user=root;password=;"
                )
            );

            return new MySqlContext(optionsBuilder.Options);
        }
    }
}
