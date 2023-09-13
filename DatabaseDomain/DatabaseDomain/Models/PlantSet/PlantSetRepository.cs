using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantSetRepository : Repository<PlantSet>
    {
        public PlantSetRepository(DbContext database) : base(database)
        {
        }


        //public Player GetPlayerOwner(int id)
        //{
        //    PlantSet plantSet = Get(id);
        //    return plantSet.Player;
        //}



    }
}
