using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class UserFlightSearchModel
    {
        [Required]
        [NotMapped]
        public string Origin { get; set; }

        [Required]
        [NotMapped]
        public string Destination { get; set; }

        [Required]
        [NotMapped]
        public DateOnly Departure { get; set; }

        [NotMapped]
        public DateOnly Return { get; set; }

        public string Way { get; set; }

        [NotMapped]
        public List<string>? AllOrigins { get; set; }

        [NotMapped]
        public List<string>? AllDestinations { get; set; }


    }
}
