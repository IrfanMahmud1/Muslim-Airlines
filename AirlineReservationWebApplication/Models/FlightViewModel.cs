using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Models
{
    public class FlightViewModel
    {
        [Key]
        public int Flight_No { get; set; }

        [DataType(DataType.Date)]
        public DateTime Departure_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival_Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Departure_Time { get; set; }

        [DataType(DataType.Time)]
        public DateTime Arrival_Time { get; set; }

        [Required]
        public string Departure_Place {  get; set; }

        [Required]
        public string Arrival_Place {  get; set; }

        [Required]
        public int Available_Seats { get; set; }

        [Required]
        public string Aircraft_Model { get; set; }

        [Required]
        public string Flight_Type { get; set; }

        [Required]
        public string Flight_Status { get; set; }

        [Required]
        public bool Booked { get; set; }
    }
}
