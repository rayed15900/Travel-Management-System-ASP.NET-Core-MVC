using System.ComponentModel.DataAnnotations;

namespace Travel_Management_System.EF.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(300)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Availability { get; set;}
        [Required]
        public int Duration { get; set; }
        [Required]
        public string LocationsToVisit { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Transport> Transports { get; set; }
        public virtual ICollection<Hotel> Hotels { get; set; }

        public Package()
        {
            Bookings = new List<Booking>();
            Transports = new List<Transport>();
            Hotels = new List<Hotel>();
        }
    }
}