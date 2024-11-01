using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VoleyballWpf3.Models
{
    public class Team
    {
        [Key]
        public int Id_Team { get; set; }
        public string Title { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }

        // Navigation properties
        public virtual ICollection<Game> GamesAsTeam_1 { get; set; }
        public virtual ICollection<Game> GamesAsTeam_2 { get; set; }
        public virtual ICollection<Team_Composition> Team_Compositions { get; set; }
        //public virtual ICollection<Training_Time> Training_Times { get; set; }
    }
}
