using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class OfferViewModel
    {
        [Key]
        public int Offer_Id { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Start_Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Start_Time { get; set; }

        [DataType(DataType.Date)]
        public DateOnly End_Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly End_Time { get; set; }

        public TimeSpan Validity { get; set; }

        [Required]        
        public int Offer_Range { get; set; }

        public int Hotel_Id { get; set; }

        [NotMapped]
        public List<(string,int)>AllHotels { get; set; }
  
        public int Flight_Id { get; set; }

        [NotMapped]
        public List<(string, int)> AllFlights { get; set; }
    }
}
