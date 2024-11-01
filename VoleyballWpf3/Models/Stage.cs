using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoleyballWpf3.Models
{
    public class Stage
    {
        [Key]
        public int Id_Stage { get; set; }
        public string Title { get; set; }

        // Navigation properties
        public virtual ICollection<Game> Games { get; set; }
    }

}
