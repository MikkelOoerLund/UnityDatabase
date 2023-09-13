using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseDomain
{

    [Table("PlantSet")]
    public class PlantSet
    {
        [Key]
        public int PlantSetId { get; set; }

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }
    }

}
