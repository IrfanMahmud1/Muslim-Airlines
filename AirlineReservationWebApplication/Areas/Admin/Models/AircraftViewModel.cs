using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Areas.Admin.Models
{
    public class AircraftViewModel
    {
        [Key]
        public int Aircraft_Id { get; set; }

        [Required]
        public string Aircraft_Name { get; set; }

        [Required]
        public string Aircraft_Category { get; set; }

        [Required]
        public int Seat_Capacity { get; set; }

        [Required]
        public string Aircraft_Type { get; set; }

        public bool Availability { get; set; } = true;

    }
}
