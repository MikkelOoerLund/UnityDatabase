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
        [Key] public int ZombieId { get; set; }

        [Required] public int Health { get; set; }
        [Required] public string Name { get; set; }
        [Required] public double Speed { get; set; }
    }
}
