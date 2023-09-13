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

        [Required] public int Balance { get; set; }
        [Required] public string PlayTime { get; set; }
        [Required] public string CurrentWorld { get; set; }
    }

}
