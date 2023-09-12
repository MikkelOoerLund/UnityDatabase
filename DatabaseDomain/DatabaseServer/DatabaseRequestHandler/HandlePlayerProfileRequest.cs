using DatabaseDomain;
using DatabaseDomain.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class HandlePlayerProfileRequest : IRequestHandler<DatabaseRequest>
    {
        private PlayerProfileCollection _playerProfileCollection;

        public HandlePlayerProfileRequest(PlayerProfileCollection playerProfileCollection)
        {
            _playerProfileCollection = playerProfileCollection;
        }

        public object HandleRequest(DatabaseRequest request)
        {
            if (request.EntityTarget != EntityTarget.PlayerProfile)
            {
                throw new Exception();
            }

            switch (request.QueryTask)
            {
                case QueryTask.GetAll: return _playerProfileCollection.GetPlayers();
                default: throw new Exception();
            }
        }
    }
}
