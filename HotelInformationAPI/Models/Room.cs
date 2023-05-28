using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelInformationAPI.Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Hotel")]
        [Column("HotelId")]
        public int HotelId { get; set; }
        public Hotel? Hotel { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public string RoomType { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
