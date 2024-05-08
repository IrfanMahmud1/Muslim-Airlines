using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class PrivateServiceViewModel
    {
        [Key]
        public int PrivateS_Id {  get; set; }

        [DataType(DataType.Date)]
        public DateTime Departure_Date { get; set; }

        [DataType(DataType.Date)]
        public DateTime Arrival_Date { get; set; }

        [DataType(DataType.Time)]
        public DateTime Departure_Time { get; set; }
        
        [DataType(DataType.Time)]
        public DateTime Arrival_Time { get; set; }

        [Required]
        public string Departure_Place { get; set; }

        [Required]
        public string ArrivalPlace { get; set; }

        [Required]
        public string Service_Category { get; set; }

        public int Aircraft_Model {  get; set; }
        [ForeignKey("Aircraft_Model")]
        public AircraftViewModel aircraftViewModel { get; set; }


    }
}
