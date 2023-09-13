using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    public class PlantVsZombiesDbContext : DbContext
    {
        public PlantVsZombiesDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PlantVsZombiesDbContext>());
        }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Zombie> Zombies { get; set; }
        public DbSet<PlantSet> PlantSets { get; set; }
        public DbSet<PlantSetPlantLink> PlantSetPlantLinks { get; set; }
    }
}
