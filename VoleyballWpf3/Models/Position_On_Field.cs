using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyballWpf3.Models
{
    [Table("Positions_On_Field")]
    public class Position_On_Field
    {
        [Key]
        public int Id_Position_On_Field {  get; set; } 
        public string Title { get; set; }

        // Nav
        public ICollection<Team_Composition> Team_Compositions { get; set; }
    }
}
