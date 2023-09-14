using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseDomain
{

    [Table("Player")]
    public class Player
    {
        [Key] public int PlayerId { get; set; }

        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public int Balance { get; set; }

        public string PlayTime { get; set; }

        public virtual Area Area { get; set; }
    }

}
