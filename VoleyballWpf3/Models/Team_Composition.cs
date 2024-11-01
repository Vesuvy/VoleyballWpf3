using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyballWpf3.Models
{
    [Table("Team_Compositions")]
    public class Team_Composition
    {
        [Key]
        public int Id_Team_Composition { get; set; }

        [ForeignKey("Teams")]
        [Column("Fk_Team")]
        public int TeamId { get; set; }

        [ForeignKey("People")]
        [Column("Fk_People_Sport")]
        public int PeopleSportId { get; set; }

        [ForeignKey("Positions_On_Field")]
        [Column("Fk_Position_On_Field")]
        public int PositionOnFieldId { get; set; }

        public virtual Team Team { get; set; }
        public virtual People People { get; set; }
        public virtual Position_On_Field Position_On_Field { get; set; }

    }
}
