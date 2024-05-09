using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class FeedbackViewModel
    {
        [Key]
        public int Feedback_Id { get; set; }

        public int Passenger_Id { get; set; }
        [ForeignKey("Passenger_Id")]
        public PassengerViewModel passengerViewModel { get; set; }

        [Required]
        public string Passenger_Feedback {  get; set; }
    }
}
