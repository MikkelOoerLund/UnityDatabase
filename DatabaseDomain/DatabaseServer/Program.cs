using DatabaseDomain;
using DatabaseDomain.Network;
using DatabaseDomain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConnectionStringFactory.CreateConnectionStringToDatabase("DESKTOP-3NHSSF9", "PlantVsZombies");
            PlayerDatabase database = new PlayerDatabase(connectionString);
            PlayerProfileRepository repository = new PlayerProfileRepository(database);
            PlayerProfileCollection playerProfileCollection = new PlayerProfileCollection(repository);

            HandleDatabaseRequest databaseRequestPublisher = new HandleDatabaseRequest(new RequestPublisher<DatabaseRequest>()
            {
                new HandlePlayerProfileRequest(playerProfileCollection),
            });


            List<IRequestHandler> requestHandlers = new List<IRequestHandler>()
            {
                databaseRequestPublisher,
            };


            RequestPublisher requestPublisher = new RequestPublisher(requestHandlers);



            TCPListener listener = new TCPListener(12000, requestPublisher);

            listener.Start();
            listener.AcceptClientsAsync();

            Console.ReadLine();
        }
    }
}
