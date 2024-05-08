using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class OfferViewModel
    {
        [Key]
        public int Offer_Id { get; set; }

        
        public DateTime Start_Date { get; set; }

        public TimeSpan Validity { get; set; }

        [Required]        
        public int Offer_Range { get; set; }

        [Required]
        public string Offer_For { get; set; }

        public int Hotel_Id { get; set; }
        [ForeignKey("Hotel_Id")]
        public virtual HotelViewModel hotelViewModel { get; set; }

        public int Flight_Id { get; set; }
        [ForeignKey("Flight_Id")]
        public virtual FlightViewModel flightViewModel{ get; set; }
    }
}
