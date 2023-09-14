using DatabaseDomain;
using Domain.Network;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
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
            TCPClient client = new TCPClient(12000);
            client.Connect();

            var requestFactory = new DatabaseRequestFactory();
            var databaseClient = new TCPDatabaseClient(client, requestFactory);


            client.SendRequest("Yooo");

            Console.WriteLine(client.RecieveResponse());

            //Area[] areas = databaseClient.GetEntities<Area>();


            //foreach (var item in areas)
            //{
            //    Console.WriteLine(item);
            //}



            //Console.WriteLine(area);

            Console.ReadKey();
        }
    }
}

