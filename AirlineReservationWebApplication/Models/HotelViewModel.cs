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
        public int Total_Rooms { get; set; }

        public int Booked_Rooms { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Checkin_Date { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Checkout_Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Checkin_Time { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Checkout_Time { get; set; }

        [Required]
        public string Country {  get; set; }


    }
}
