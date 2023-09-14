using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class DatabaseRequestFactory
    {
        private Dictionary<(Type, QueryTask), DatabaseRequest> _databaseRequests;
        
        public DatabaseRequestFactory()
        {
            _databaseRequests = new Dictionary<(Type, QueryTask), DatabaseRequest>();
        }

        public DatabaseRequest GetDatabaseRequest(Type entityType, QueryTask queryTask)
        {
            var key = (entityType, queryTask);

            if (_databaseRequests.ContainsKey(key))
            {
                return _databaseRequests[key];
            }

            var databaseRequest = new DatabaseRequest()
            {
                QueryTask = queryTask,
                Type = entityType,
            };

            _databaseRequests.Add(key, databaseRequest);
            return _databaseRequests[key];
        }
    }
}
