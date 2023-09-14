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
            client.WaitUntilConnected();

            var areaDatabaseClient = new TCPDatabaseClient<Area>(client, new DatabaseRequestFactory());

            Area area = areaDatabaseClient.GetEntityWithId(1);



            Console.WriteLine(area);

            Console.ReadKey();
        }
    }
}

