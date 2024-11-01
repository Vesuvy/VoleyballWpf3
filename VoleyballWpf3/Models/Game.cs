using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyballWpf3.Models
{
    public class Game
    {
        [Key]
        public int Id_Game { get; set; }
        public int Score_Team_1 { get; set; }
        public int Score_Team_2 { get; set; }
        public DateTime Start_Game_Time { get; set; }
        public DateTime End_Game_Time { get; set; }

        [ForeignKey("Stages")]
        [Column("Fk_Stage")]
        public int StageId { get; set; }

        [ForeignKey("Teams")]
        [Column("Fk_Team_1")]
        public int Team_1Id { get; set; }

        [ForeignKey("Teams")]
        [Column("Fk_Team_2")]
        public int Team_2Id { get; set; }

        //[ForeignKey("Halls")]
        //[Column("Fk_Hall")]
        //public int HallId { get; set; }

        //[ForeignKey("Tournaments")]
        //[Column("Fk_Tournament")]
        //public int TournamentId { get; set; }

        public virtual Stage Stage { get; set; }
        public virtual Team Team_1 { get; set; }
        public virtual Team Team_2 { get; set; }
        //public virtual Hall Hall { get; set; }
        //public virtual Tournament Tournament { get; set; }

        public ICollection<Judge> Judges { get; set; }
    }
}
