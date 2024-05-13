using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class ReservationViewModel
    {
        [Key]
        public int Reservation_Id { get; set; }

        [Required]
        public int Passenger_Id { get; set; }

        [Required]
        public string Passenger_Name { get; set; }
        public int Flight_No { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Flight_Booking_Date { get; set; }

        [Required]
        public int Payment_Id { get; set; }

        public int Transport_Id { get; set; }

        public int Hotel_Id { get; set; }

        public int PrivateService_Id { get; set; }

    }
}
