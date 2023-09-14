using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{

    [Table("Zombie")]
    public class Zombie
    {
        [Key] 
        public int ZombieId { get; set; }

        [MaxLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Health { get; set; }
        public int Speed { get; set; }

    }
}
