using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    [Table("Plant")]
    public class Plant
    {
        [Key] public int PlantId { get; set; }

        [MaxLength(450)]
        [Index(IsUnique = true)] 
        public string Name { get; set; }
        public string Description { get; set; }

        public int Cost { get; set; }
        public int Damage { get; set; }
        public int Recharge { get; set; }

        public string Range { get; set; }
        public string Toughness { get; set; }
    }
}
