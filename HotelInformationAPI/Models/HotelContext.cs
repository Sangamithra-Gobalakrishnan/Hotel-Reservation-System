using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace HotelInformationAPI.Models
{
    public class HotelContext:DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Hotel> HotelInformation { get; set; }
        public DbSet<Room> RoomInformation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                     HotelId = 101,
                     Name = "Grand Hotel",
                     Description = "A luxurious hotel offering a memorable stay.",
                     Address = "123 Main Street",
                     ContactNumber = "9867453212",
                     City = "New York City",
                     Country = "United States",
                     AverageRating = 4.5,
                     NumberOfRooms = 100,
                     MinimumPriceRange = 5000,
                     MaximumPriceRange = 400000
                }
        );
        }
    }
}
