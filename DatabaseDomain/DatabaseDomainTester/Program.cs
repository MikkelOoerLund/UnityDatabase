using DatabaseDomain;
using DatabaseDomain.Network;
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
    internal interface IRequestHandler
    {
        object HandleRequest<T>(T request);
    }

    internal interface IRequestHandler<T> : IRequestHandler
    {
        new object HandleRequest<T>(T request);
    }

    internal class GenereicRequestHandler<T> : IRequestHandler<T>
    {
        public object HandleRequest<T>(T request)
        {
            Console.WriteLine($"Handling {typeof(T)}");
            return null;
        }
    }


    internal class RequestPublisher : Dictionary<Type, List<IRequestHandler>>
    {
        public void Add<T>(IRequestHandler<T> requestHandler)
        {
            Type type = typeof(T);

            if (ContainsKey(type))
            {
                this[type].Add(requestHandler);
                return;
            }

            this[type] = new List<IRequestHandler>()
            {
                requestHandler,
            };

        }

        public void PublishRequest<T>(T request)
        {
            Type type = typeof(T);

            foreach (var requestHandler in this[type])
            {
                requestHandler.HandleRequest(request);
            }
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-3NHSSF9",
                InitialCatalog = "PlantsVsZombies",
                IntegratedSecurity = true,
            };

            var connectionString = builder.ConnectionString;

            var databaseContext = new PlantVsZombiesDbContext(connectionString);
            databaseContext.Database.Initialize(force: true);


            var plantRepository = new PlantRepository(databaseContext);
            var playerRepository = new PlayerRepository(databaseContext);
            var zombieRepository = new ZombieRepository(databaseContext);
            var plantSetRepository = new PlantSetRepository(databaseContext);
            var plantSetPlantLinkRepository = new PlantSetPlantLinkRepository(databaseContext);

            //plantRepository.GetAll();
            //playerRepository.GetAll();

            Console.WriteLine("Press any key to close the terminal...");
            Console.ReadKey();
        }
    }
}
