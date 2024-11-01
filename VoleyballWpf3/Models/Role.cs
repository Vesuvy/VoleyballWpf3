using System.ComponentModel.DataAnnotations;

namespace VoleyballWpf3.Models
{
    public class Role
    {
        [Key]
        public int Id_Role { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<People> People { get; set; }
    }
}
