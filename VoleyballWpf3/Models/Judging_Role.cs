using System.ComponentModel.DataAnnotations;

namespace VoleyballWpf3.Models
{
    public class Judging_Role
    {
        [Key]
        public int Id_Judging_Role { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<Judge> Judges { get; set; }
    }
}
