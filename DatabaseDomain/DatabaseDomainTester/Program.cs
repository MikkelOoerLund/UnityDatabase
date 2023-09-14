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

            int id = 1;

            var databaseRequest = new DatabaseRequest<int>()
            {
                QueryTask = QueryTask.GetEntityWithId,
                EntityType = EntityType.Area,
                Data = id,
            };

            client.SendRequest(databaseRequest);
            var response = client.RecieveResponse<Area>();

            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}

