using DatabaseDomain;
using DatabaseDomain.Network;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class HandleDatabaseRequest : IRequestHandler
    {
        private RequestPublisher<DatabaseRequest> _requestPublisher;

        public HandleDatabaseRequest(RequestPublisher<DatabaseRequest> requestPublisher)
        {
            _requestPublisher = requestPublisher;
        }


        public object HandleRequest(string request)
        {
            DatabaseRequest databaseRequest = JsonConvert.DeserializeObject<DatabaseRequest>(request);

            if (databaseRequest == null)
            {
                throw new Exception();
            }


            return _requestPublisher.Publish(databaseRequest);
        }
    }
}
