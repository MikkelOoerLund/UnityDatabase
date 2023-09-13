using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseDomain
{
    /// <summary>
    /// Represents the many-to-many relationship between the PlantS and Plant models
    /// </summary>
    [Table("PlantSetPlantLink")]
    public class PlantSetPlantLink
    {
        [Key]
        public int PlantSetPlantLinkId { get; set; }

        [ForeignKey("PlantSet")]
        public int PlantSetId { get; set; }

        [ForeignKey("Plant")]
        public int PlantId { get; set; }

        public virtual PlantSet PlantSet { get; set; }

        public virtual Plant Plant { get; set; }
    }

}
