using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VoleyballWpf3.Models
{
    public class Distribution_Hotel
    {
        [Key]
        public int Id_Distribution_Hotel { get; set; }

        [ForeignKey("Team_Compositions")]
        [Column("Fk_Team_Composition")]
        public int TeamCompositionId { get; set; }

        [ForeignKey("Tournaments")]
        [Column("Fk_Tournament")]
        public int TournamentId { get; set; }

        [ForeignKey("Hotel_Numbers")]
        [Column("Fk_Hotel_Number")]
        public int HotelNumberId { get; set; }

        //public virtual Team_Compositions TeamComposition { get; set; }
        //public virtual Tournaments Tournament { get; set; }
        //public virtual Hotel_Numbers HotelNumber { get; set; }
    }
}
