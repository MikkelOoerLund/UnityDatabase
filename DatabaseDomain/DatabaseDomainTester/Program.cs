using DatabaseDomain;
using DatabaseDomain.Network;
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

    internal class Message
    {
        public string Text { get; set; }

        public Message(string text)
        {
            Text =  text;
        }
    }

    internal class Publisher
    {
        private Message _message;

        public Publisher(Message message)
        {
            _message = message;
        }

        public void Publish()
        {
            Console.WriteLine(_message.Text);
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //var databaseContext = new PlantVsZombiesDbContext(connectionString);
            //databaseContext.Database.Initialize(force: true);


            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-3NHSSF9",
                InitialCatalog = "PlantsVsZombies",
                IntegratedSecurity = true,
            };

            var connectionString = builder.ConnectionString;

            var hostApplicationBuilder = Host.CreateApplicationBuilder(args);

            var services = hostApplicationBuilder.Services;
            services.AddTransient<PlantRepository>();
            services.AddTransient<PlayerRepository>();
            services.AddTransient<ZombieRepository>();
            services.AddTransient<PlantSetPlantLinkRepository>();
            services.AddSingleton(typeof(DbContext), provider => new PlantVsZombiesDbContext(connectionString));

            var host = hostApplicationBuilder.Build();

            var hostServices = host.Services;
            var serviceScope = hostServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            var plantRepository = serviceProvider.GetRequiredService<PlantRepository>();
            plantRepository.GetAll();


            Console.WriteLine("Press any key to close the terminal...");
            Console.ReadKey();
        }
    }
}

