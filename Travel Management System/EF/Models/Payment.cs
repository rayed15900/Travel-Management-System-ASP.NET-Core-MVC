using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Management_System.EF.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [ForeignKey("Bookings")]
        public int BookingId { get; set; }
        public virtual Booking Bookings { get; set; }
    }
}
