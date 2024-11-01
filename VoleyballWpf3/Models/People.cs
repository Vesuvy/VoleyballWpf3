using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

namespace VoleyballWpf3.Models
{
    public class People
    {
        [Key]
        public int Id_People { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Familiya { get; set; }
        public string Otchestvo { get; set; }
        public string Telephone { get; set; }

        [ForeignKey("Roles")]
        [Column("Fk_Role")]
        public int RoleId { get; set; }
        
        public virtual Role Role { get; set; }

        // Navigation properties
        public virtual ICollection<Judge> Judges { get; set; }
        public virtual ICollection<Team_Composition> Team_Compositions { get; set; }
        public virtual ICollection<Ticket_Sale> Ticket_Sales { get; set; }
    }
}
