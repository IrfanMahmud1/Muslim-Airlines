using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Models
{
    public class TransportViewModel
    {
        [Key]
        public int Transport_Model { get; set; }

        [Required]
        public string Transport_Category { get; set; }

        [Required]
        public int Available_Seats { get; set; }

        [Required]
        public int Total_Seats { get; set; }
        [Required]
        public int Seat_Booked { get; set; }

        [DataType(DataType.Time)]
        public DateTime PickUp_Time { get; set; }

        [Required]
        public string PickUp_Place {  get; set; }

        [DataType(DataType.Date)]
        public DateTime Transport_Date { get; set; }
    }
}
