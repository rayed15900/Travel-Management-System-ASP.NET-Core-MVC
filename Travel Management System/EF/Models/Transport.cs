using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Management_System.EF.Models
{
    public class Transport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string TransportName { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartureLocation { get; set; }
        [Required]
        [StringLength(50)]
        public string ArrivalLocation { get; set; }
        [Required]
        public DateTime DepartureTime { get; set;}
        [Required]
        public DateTime ArrivalTime { get; set;}
        [Required]
        public int SeatCapacity { get; set; }

        [Required]
        [ForeignKey("Packages")]
        public int PackageId { get; set; }
        public virtual Package Packages { get; set; }
    }
}
