using Microsoft.EntityFrameworkCore;
using Travel_Management_System.EF.Models;

namespace Travel_Management_System.EF
{
    public class TravelDb : DbContext
    {
        public TravelDb(DbContextOptions<TravelDb> options) : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
