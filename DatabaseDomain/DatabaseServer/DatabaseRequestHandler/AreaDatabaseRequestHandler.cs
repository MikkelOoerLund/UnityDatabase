using DatabaseDomain;
using Domain.Observer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class AreaDatabaseRequestHandler : IRequestHandler
    {
        private AreaRepository _areaRepository;

        public AreaDatabaseRequestHandler(AreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public object HandleRequest(string request)
        {
            var databaseRequest = JsonConvert.DeserializeObject<DatabaseRequest<int>>(request);
            if (databaseRequest == null) return null;
            var id = databaseRequest.Data;

            return _areaRepository.Get(id);
        }

   
    }
}
