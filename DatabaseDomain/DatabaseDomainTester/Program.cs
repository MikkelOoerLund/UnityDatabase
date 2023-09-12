using DatabaseDomain;
using DatabaseDomain.Network;
using DatabaseDomain.Players;
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
    internal abstract class RequestHandler
    {
        public abstract object HandleRequest<T>(T request);
    }

    internal class RequestHandler<T> : RequestHandler
    {
        public override object HandleRequest<T>(T request)
        {
            Console.WriteLine(request);
            return null;
        }

    }

    internal class RequestPublisher : Dictionary<Type, List<RequestHandler>>
    {
        public void Add<T>(RequestHandler<T> requestHandler)
        {
            Type type = typeof(T);

            if (ContainsKey(type))
            {
                this[type].Add(requestHandler);
                return;
            }

            this[type] = new List<RequestHandler>()
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
            RequestHandler<int> requestHandler = new RequestHandler<int>();
            RequestHandler<string> stringRequestHandler = new RequestHandler<string>();

            RequestPublisher requestPublisher = new RequestPublisher
            {
                requestHandler,
                stringRequestHandler,
            };


            requestPublisher.PublishRequest("StringRequest");

            //TCPClient client = new TCPClient(12000);

            //client.Connect();

            //DatabaseRequest databaseRequest = new DatabaseRequest()
            //{
            //    EntityTarget = EntityTarget.PlayerProfile,
            //    QueryTask = QueryTask.GetAll,
            //};

            //client.SendRequest(databaseRequest);
            //PlayerProfile[] playerProfiles = client.RecieveResponse<PlayerProfile[]>();


            //foreach (var item in playerProfiles)
            //{
            //    Console.WriteLine($"Id: {item.Id}, TotalPlayTime: {item.TotalPlayTimeInTimeSpan}");
            //}

            Console.ReadKey();

        }
    }
}
