using DatabaseDomain;
using Domain.Network;

namespace DatabaseDomainTester
{
    public class TCPDatabaseClient<TEntityTarget>
    {
        private TCPClient _client;
        private DatabaseRequestFactory _databaseRequestFactory;


        public TCPDatabaseClient(TCPClient client, DatabaseRequestFactory databaseRequestFactory)
        {
            _client = client;
            _databaseRequestFactory = databaseRequestFactory;
        }

        public TEntityTarget GetEntityWithId(int id)
        {
            var entityType = typeof(TEntityTarget);
            var queryTask = QueryTask.GetWithId;
            var request = _databaseRequestFactory.GetDatabaseRequest(entityType, queryTask);

            request.Data = id.ToString();

            _client.SendRequest(request);
            return _client.RecieveResponse<TEntityTarget>();
        }

        public TEntityTarget[] GetEntities()
        {
            var entityType = typeof(TEntityTarget);
            var queryTask = QueryTask.GetAll;
            var request = _databaseRequestFactory.GetDatabaseRequest(entityType, queryTask);

            _client.SendRequest(request);
            return _client.RecieveResponse<TEntityTarget[]>();
        }
    }
}
