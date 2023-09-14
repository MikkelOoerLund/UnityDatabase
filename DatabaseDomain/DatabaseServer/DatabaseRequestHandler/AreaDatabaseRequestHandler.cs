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
            var databaseRequest = JsonConvert.DeserializeObject<DatabaseRequest>(request);
            if (databaseRequest == null) return null;
            if (databaseRequest.Type != typeof(Area)) return null;

            var data = databaseRequest.Data;
            var id = int.Parse(data);

            var response = _areaRepository.Get(id);

            Console.WriteLine(response);

            switch (databaseRequest.QueryTask)
            {
                case QueryTask.GetWithId: return response;
                //case QueryTask.GetEntityWithName: return _areaRepository.GetAreaWithName(entity.Name);


                default: throw new Exception();
            }

            throw new Exception();
        }

    


   
    }
}
