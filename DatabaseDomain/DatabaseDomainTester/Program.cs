using DatabaseDomain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseDomainTester
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

//var databaseContext = new PlantVsZombiesDbContext(connectionString);
//databaseContext.Database.Initialize(force: true);