using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheBindery.Infrastructure.EFCore.SqlServer
{
    public class DbInitializer
    {

        protected DbInitializer() { }

        public static async Task Seed(TheBinderyDataContext context)
        {

            context.Database.EnsureCreated();
        }

    }
}
