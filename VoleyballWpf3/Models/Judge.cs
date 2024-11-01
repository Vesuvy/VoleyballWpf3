using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyballWpf3.Models
{
    public class Judge
    {
        [Key]
        public int Id_Judge { get; set; }

        [ForeignKey("Games")]
        [Column("Fk_Game")]
        public int GameId { get; set; }

        [ForeignKey("Peoples")]
        [Column("Fk_People_Judge")]
        public int People_JudgeId { get; set; }

        [ForeignKey("Judging_Roles")]
        [Column("Fk_Judging_Role")]
        public int Judging_RoleId { get; set; }

        public virtual Game Game { get; set; }
        public virtual People People { get; set; }
        public virtual Judging_Role Judging_Role { get; set; }
    }
}
