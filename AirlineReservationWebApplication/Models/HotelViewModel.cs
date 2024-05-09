using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Models
{
    public class HotelViewModel
    {
        [Key]
        public int Hotel_Id { get; set; }

        [Required]
        public string Hotel_Name { get; set; }
        [Required]
        public string Hotel_Location { get; set; }

        [Required]
        public string Room_Category { get; set; }

        [Required]
        public int Available_Rooms { get; set; }

        [Required]
        public int Room_Booked { get; set; }
        [Required]
        public bool Room_Availability { get; set; }

        [DataType(DataType.Date)]
        public DateTime Hotel_Date { get; set; }

        [Required]
        public string Place {  get; set; }


    }
}
