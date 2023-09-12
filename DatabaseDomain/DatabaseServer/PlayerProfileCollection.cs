using DatabaseDomain.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseServer
{
    internal class PlayerProfileCollection
    {
        private PlayerProfileRepository _playerProfileRepository;


        public PlayerProfileCollection(PlayerProfileRepository playerProfileRepository)
        {
            _playerProfileRepository = playerProfileRepository;
        }

        public PlayerProfile[] GetPlayers()
        {
            PlayerProfile[] playerProfiles = _playerProfileRepository.GetAll().ToArray();
            _playerProfileRepository.Dispose();
            return playerProfiles;
        }
    }
}
