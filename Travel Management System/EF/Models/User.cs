using System.ComponentModel.DataAnnotations;

namespace Travel_Management_System.EF.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set;}
        [Required]
        [StringLength(30)]
        public string Role { get; set;}

        public virtual ICollection<Booking> Bookings { get; set;}

        public User()
        {
            Bookings = new List<Booking>();
        }
    }
}