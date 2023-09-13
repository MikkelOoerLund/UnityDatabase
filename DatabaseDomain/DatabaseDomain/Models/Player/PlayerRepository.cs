using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlayerRepository : Repository<Player>
    {
        public PlayerRepository(DbContext database) : base(database)
        {

        }


    }
}
