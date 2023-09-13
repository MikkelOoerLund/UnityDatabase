using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantRepository : Repository<Plant>
    {
        public PlantRepository(DbContext database) : base(database)
        {
        }
    }
}
