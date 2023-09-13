using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantBuilder
    {
        private Plant _plant;

        public PlantBuilder()
        {
            _plant = new Plant();
        }

        public PlantBuilder SetSunCost(int sunCost)
        {
            _plant.Cost = sunCost;
            return this;
        }

        public PlantBuilder SetRechargeCooldown(int rechargeCooldown)
        {
            _plant.Recharge = rechargeCooldown;
            return this;
        }

        public PlantBuilder SetName(string name)
        {
            _plant.Name = name;
            return this;
        }

        public PlantBuilder SetDescription(string description)
        {
            _plant.Description = description;
            return this;
        }

        public Plant Build()
        {
            return _plant;
        }
    }

}
