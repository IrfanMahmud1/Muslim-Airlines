using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class ReservationViewModel
    {
        [Key]
        public int Reservation_Id { get; set; }

        public int Passenger_Id { get; set; }
        [ForeignKey("Passenger_Id")]
        public virtual PassengerViewModel passengerViewModel { get; set; }

        [Required]
        public string Passenger_Name { get; set; }
        public int Flight_No { get; set; }
        [ForeignKey("Flight_No")]
        public virtual FlightViewModel flightViewModel { get; set; }

        [DataType(DataType.Date)]
        public DateTime Flight_Booking_Date { get; set; }

        public int Payment_Id { get; set; }
        [ForeignKey("Payment_Id")]
        public virtual PaymentViewModel paymentViewModel { get; set; }

        public int Transport_Id { get; set; }
        [ForeignKey("Transport_Id")]
        public virtual TransportViewModel transportViewModel { get; set; }

        public int Hotel_Id { get; set; }
        [ForeignKey("Hotel_Id")]
        public virtual HotelViewModel hotelViewModel { get; set; }

        public int PrivateService_Id { get; set; }
        [ForeignKey("PrivateService_Id")]
        public virtual PrivateServiceViewModel privateServiceViewModel { get; set; }

    }
}
