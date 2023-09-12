using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain.Players
{
    public class PlayerDatabase : DbContext
    {
        public PlayerDatabase(string connectionString) : base(connectionString)
        {
        }
        public DbSet<PlayerProfile> PlayerProfiles { get; }
    }
}
