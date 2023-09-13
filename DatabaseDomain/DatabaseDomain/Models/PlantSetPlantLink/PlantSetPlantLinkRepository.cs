using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantSetPlantLinkRepository : Repository<PlantSetPlantLink>
    {
        public PlantSetPlantLinkRepository(DbContext database) : base(database)
        {
        }
    }
}
