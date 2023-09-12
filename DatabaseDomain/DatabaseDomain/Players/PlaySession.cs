using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain.Players
{
    public class PlaySession
    {
        private Stopwatch _stopWatch;
        private PlayerProfile _playerProfile;
        private PlayerProfileRepository _playerRepository;


        public PlaySession(PlayerProfile playerProfile, PlayerProfileRepository playerProfileRepository)
        {
            _stopWatch = new Stopwatch();
            _playerProfile = playerProfile;
            _playerRepository = playerProfileRepository;
        }

        public void Start()
        {
            _stopWatch.Start();
        }

        public void Stop()
        {
            _stopWatch.Stop();
        }


        public TimeSpan GetSessionTime()
        {
            return _stopWatch.Elapsed;
        }

        public DateTime GetTotalPlayTime()
        {
            return _playerProfile.TotalPlayTime.Add(GetSessionTime());
        }



    }
}
