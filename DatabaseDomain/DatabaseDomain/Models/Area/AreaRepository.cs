using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class AreaRepository : Repository<Area>
    {
        public AreaRepository(DbContext database) : base(database)
        {
        }
    }
}
