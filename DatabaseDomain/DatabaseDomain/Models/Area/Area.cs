using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDomain
{
    [Table("Area")]
    public class Area
    {
        [Key] public int AreaId { get; set; }

        [MaxLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public int LevelCount { get; set; }
        public int Difficulty { get; set; }


        public override string ToString()
        {
            return $"AreaId: {AreaId}\n" +
                $"Name: {Name}\n" +
                $"LevelCount: {LevelCount}\n" +
                $"Difficulty: {Difficulty}\n";
        }
    }
}
