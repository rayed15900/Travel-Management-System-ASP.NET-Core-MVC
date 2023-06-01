using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travel_Management_System.EF.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Location { get; set; }
        [Required]
        public int NumberOrRooms { get; set; }
        [Required]
        public double PricePerNight { get; set; }

        [Required]
        [ForeignKey("Packages")]
        public int PackageId { get; set; }
        public virtual Package Packages { get; set; }
    }
}
