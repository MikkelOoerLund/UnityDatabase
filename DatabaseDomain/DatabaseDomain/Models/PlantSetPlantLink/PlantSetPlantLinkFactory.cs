using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantSetPlantLinkFactory
    {
        public static PlantSetPlantLink Create(PlantSet plantSet, Plant plant)
        {
            return new PlantSetPlantLink
            {
                PlantSetId = plantSet.PlantSetId,
                PlantId = plant.PlantId,

                PlantSet = plantSet,
                Plant = plant
            };
        }
    }

}
