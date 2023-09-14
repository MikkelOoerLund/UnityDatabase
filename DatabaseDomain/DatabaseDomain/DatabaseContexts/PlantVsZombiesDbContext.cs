using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Area>()
               .HasIndex(a => a.Name)
               .IsUnique();

            modelBuilder.Entity<Plant>()
             .HasIndex(a => a.Name)
             .IsUnique();

            modelBuilder.Entity<Zombie>()
             .HasIndex(a => a.Name)
             .IsUnique();
        }


        public DbSet<Area> Areas { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Zombie> Zombies { get; set; }
        public DbSet<PlantSet> PlantSets { get; set; }
        public DbSet<PlantSetPlantLink> PlantSetPlantLinks { get; set; }
    }
}
