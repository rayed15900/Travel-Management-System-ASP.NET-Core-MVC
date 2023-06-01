using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Management_System.EF.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly BookingDate { get; set; }
        [Required]
        [StringLength(30)]
        public string PaymentStatus { get; set; } // Pending, Paid, Cancelled
        [Required]
        public double TotalAmount { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }

        [Required]
        [ForeignKey("Packages")]
        public int PackageId { get; set; }
        public virtual Package Packages { get; set; }

        public virtual Payment Payments { get; set; }
    }
}