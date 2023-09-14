using DatabaseDomain;
using Domain.Network;
using Domain.Observer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //var hostApplicationBuilder = Host.CreateApplicationBuilder(args);
            //var servicesCollection = hostApplicationBuilder.Services;

            //var connectionString = CreateConnectionString();

            //AddDatabaseService(servicesCollection, connectionString);
            //AddDatabaseServices(servicesCollection);

            //var host = hostApplicationBuilder.Build();
            //var hostServices = host.Services;
            //var serviceScope = hostServices.CreateScope();
            //var serviceProvider = serviceScope.ServiceProvider;

            //CreateDatabaseDataIfNotExist(serviceProvider);

            //var areaRepository = serviceProvider.GetRequiredService<AreaRepository>();

            var requestPublisher = new RequestPublisher()
            {
                //new AreaDatabaseRequestHandler(areaRepository)
            };

            var listener = new TCPListener(12000, requestPublisher);

            listener.Start();
            listener.AcceptClientsAsync();



            Console.WriteLine("Server is started press any key to close the terminal...");
            Console.ReadLine();

        }

        private static void CreateDatabaseDataIfNotExist(IServiceProvider serviceProvider)
        {
            var areaFilePath = @"C:\Users\mikke\Desktop\UnityDatabase\DatabaseDomain\DatabaseServer\Data\AreaData.txt";
            var plantFilePath = @"C:\Users\mikke\Desktop\UnityDatabase\DatabaseDomain\DatabaseServer\Data\PlantData.txt";
            var zombieFilePath = @"C:\Users\mikke\Desktop\UnityDatabase\DatabaseDomain\DatabaseServer\Data\ZombieData.txt";

            var areaRepository = serviceProvider.GetRequiredService<AreaRepository>();
            var plantRepository = serviceProvider.GetRequiredService<PlantRepository>();
            var zombieRepository = serviceProvider.GetRequiredService<ZombieRepository>();

            InsertDatabaseDataIfNotExist(serviceProvider, areaRepository, areaFilePath);
            InsertDatabaseDataIfNotExist(serviceProvider, plantRepository, plantFilePath);
            InsertDatabaseDataIfNotExist(serviceProvider, zombieRepository, zombieFilePath);
        }


        private static void InsertDatabaseDataIfNotExist<TEntity>(IServiceProvider serviceProvider, Repository<TEntity> repository,  string filePath) where TEntity : class
        {
            var entities = repository.GetAll();


            if (entities.Count() == 0)
            {
                var data = LoadJsonData<TEntity>(filePath);
                repository.AddRange(data);
                repository.SaveChanges();
            }
        }



        private static void AddDatabaseService(IServiceCollection serviceCollection, string connectionString)
        {
            var context = new PlantVsZombiesDbContext(connectionString);
            serviceCollection.AddSingleton<DbContext>(context);
            context.Database.CreateIfNotExists();
        }


        private static T[] LoadJsonData<T>(string filePath)
        {
            string fileContents = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T[]>(fileContents);
        }

        private static string CreateConnectionString()
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-3NHSSF9",
                InitialCatalog = "PlantsVsZombies",
                IntegratedSecurity = true,
            };

            return connectionStringBuilder.ConnectionString;


        }

        private static void AddDatabaseServices(IServiceCollection serviceCollection)
        {
            var connectionString = CreateConnectionString();
            serviceCollection.AddTransient<AreaRepository>();
            serviceCollection.AddTransient<PlantRepository>();
            serviceCollection.AddTransient<PlayerRepository>();
            serviceCollection.AddTransient<ZombieRepository>();
            serviceCollection.AddTransient<PlantSetPlantLinkRepository>();
        }

    }
}
