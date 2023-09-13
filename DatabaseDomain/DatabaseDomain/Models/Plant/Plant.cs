﻿using System;
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

        [Required] public int SunCost { get; set; }

        [Required] public int FireCooldown { get; set; }
        [Required] public int RechargeCooldown { get; set; }

        [Required] public string Name { get; set; }
        [Required] public string Description { get; set; }
    }
}