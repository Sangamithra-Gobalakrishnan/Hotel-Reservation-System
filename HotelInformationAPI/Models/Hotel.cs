using System.ComponentModel.DataAnnotations;

namespace HotelInformationAPI.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "Must Not Exceed More Than 25 Characters")]
        public string Name { get; set; }
        
        [Required]
        [MinLength(25, ErrorMessage = "Must Be Atleast 25 Characters")]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Contact Number Must Contain 10 Characters")]
        public string ContactNumber { get; set; }
        
        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public double AverageRating { get; set; }

        [Required]
        public int NumberOfRooms { get; set; }

        [Required]
        public double MinimumPriceRange { get; set; }

        [Required]
        public double MaximumPriceRange { get; set; }
    }
}
