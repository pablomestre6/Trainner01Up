using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Infra.SqlServer.Contexts
{
    public class SqlServerContextFactory :IDesignTimeDbContextFactory
                                          <SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            return new SqlServerContext();
        }
    }
}
