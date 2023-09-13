using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlayerBuilder
    {
        private Player _player;

        public PlayerBuilder()
        {
            _player = new Player();
        }

        public PlayerBuilder SetBalance(int balance)
        {
            _player.Balance = balance;
            return this;
        }

        public PlayerBuilder SetPlayTime(string playTime)
        {
            _player.PlayTime = playTime;
            return this;
        }

        public PlayerBuilder SetCurrentWorld(string currentWorld)
        {
            _player.CurrentWorld = currentWorld;
            return this;
        }

        public Player Build()
        {
            return _player;
        }
    }
}
