using Domain;
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

        public Plant GetPlantWithName(PlantName plantName)
        {
            string plantNameString = plantName.ToString();
            string spaceBeforeUpperCaseString = StringHelper.InsertSpaceBeforeUppercase(plantNameString);
            return First(x => x.Name == spaceBeforeUpperCaseString);
        }

    }
}
