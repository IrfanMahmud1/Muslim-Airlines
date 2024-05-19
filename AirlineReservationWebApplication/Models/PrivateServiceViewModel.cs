using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class PrivateServiceViewModel
    {
        [Key]
        public int PrivateService_Id {  get; set; }

        [DataType(DataType.Date)]
        public DateOnly Departure_Date { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Arrival_Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Departure_Time { get; set; }
        
        [DataType(DataType.Time)]
        public TimeOnly Arrival_Time { get; set; }

        [Required]
        public string Departure_Place { get; set; }

        [Required]
        public string ArrivalPlace { get; set; }

        [Required]
        public string Service_Category { get; set; }

        [Required]
        public int Aircraft_Id {  get; set; }

        [NotMapped]
        public List<(string,int)> AllAircraft { get; set; }

    }
}
