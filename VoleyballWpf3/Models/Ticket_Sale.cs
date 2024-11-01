using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoleyballWpf3.Models
{
    public class Ticket_Sale
    {
        [Key]
        public int Id_Ticket_Sale { get; set; }
        public DateTime Buy_Time { get; set; }

        [ForeignKey("Games")]
        [Column("Fk_Game")]
        public int GameId { get; set; }

        [ForeignKey("People")]
        [Column("Fk_People_Buyer")]
        public int PeopleId { get; set; }

        //[ForeignKey("Tickets")]
        //[Column("Fk_Ticket")]
       // public int TicketId { get; set; }

        public virtual Game Game { get; set; }
        public virtual People People { get; set; }
        //public virtual Ticket Ticket { get; set; }
    }
}
