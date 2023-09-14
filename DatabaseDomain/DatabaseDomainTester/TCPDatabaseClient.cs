using DatabaseDomain;
using Domain.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomainTester
{
    public class TCPDatabaseClient
    {
        private TCPClient _client;
        private DatabaseRequestFactory _databaseRequestFactory;


        public TCPDatabaseClient(TCPClient client, DatabaseRequestFactory databaseRequestFactory)
        {
            _client = client;
            _databaseRequestFactory = databaseRequestFactory;
        }

        public T GetEntityWithId<T>(int id)
        {
            var entityType = typeof(T);
            var queryTask = QueryTask.GetWithId;
            var request = _databaseRequestFactory.GetDatabaseRequest(entityType, queryTask);

            request.Data = id.ToString();

            _client.SendRequest(request);
            return _client.RecieveResponse<T>();
        }

        public T[] GetEntities<T>()
        {
            var entityType = typeof(T);
            var queryTask = QueryTask.GetAll;
            var request = _databaseRequestFactory.GetDatabaseRequest(entityType, queryTask);


            _client.SendRequest(request);
            return _client.RecieveResponse<T[]>();
        }
    }
}
