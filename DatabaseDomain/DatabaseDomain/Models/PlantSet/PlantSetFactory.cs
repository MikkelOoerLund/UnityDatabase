using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantSetFactory
    {
        public static PlantSet CreateFromPlayer(Player player)
        {
            return new PlantSet
            {
                PlayerId = player.PlayerId,
                Player = player
            };
        }
    }


}
