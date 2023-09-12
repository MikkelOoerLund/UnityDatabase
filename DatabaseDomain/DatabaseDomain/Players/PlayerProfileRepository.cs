using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain.Players
{
    public class PlayerProfileRepository : Repository<PlayerProfile>
    {

        public PlayerProfileRepository(PlayerDatabase database) : base(database)
        {
        }
   
    }
}
