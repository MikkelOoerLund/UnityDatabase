using DatabaseDomain;
using Domain.Network;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PvZApiClient client = new PvZApiClient("https://pvz-2-api.vercel.app/api");


            string okay = "\" firkant   \"";
            string withOutQotes = okay.Trim('"');

            Plant plant = client.CreatePlantAsync("sunflower").Result;
            Plant[] plants = client.CreateAllPlantsAsync().Result;

            //var hostApplicationBuilder = Host.CreateApplicationBuilder(args);
            //var servicesCollection = hostApplicationBuilder.Services;

            //var connectionString = CreateConnectionString();

            //AddDatabaseServices(servicesCollection, connectionString);

            //var host = hostApplicationBuilder.Build();
            //var hostServices = host.Services;
            //var serviceScope = hostServices.CreateScope();
            //var serviceProvider = serviceScope.ServiceProvider;



            //var plantRepository = serviceProvider.GetRequiredService<PlantRepository>();

            //var plant = new Plant();

            //plant.Description = "Peashooters are your first line of defense. They shoot peas at attacking zombies.";
            //plant.RechargeCooldown = 5;
            //plant.SunCost = 100;



            //plantRepository.Add(plant);

       

            Console.ReadLine();

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

        private static void AddDatabaseServices(IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddTransient<PlantRepository>();
            serviceCollection.AddTransient<PlayerRepository>();
            serviceCollection.AddTransient<ZombieRepository>();
            serviceCollection.AddTransient<PlantSetPlantLinkRepository>();
            serviceCollection.AddSingleton<DbContext>(provider => new PlantVsZombiesDbContext(connectionString));
        }

    }
}
