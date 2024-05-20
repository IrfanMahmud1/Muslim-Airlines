using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Models
{
    public class TransportViewModel
    {
        [Key]
        public int Transport_Id { get; set; }

        [Required]
        public string Transport_Name { get; set; }

        [Required]
        public string Transport_Category { get; set; }

        [Required]
        public int Total_Seats { get; set; }

        public int Booked_Seats { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly PickUp_Time { get; set; }

        [Required]
        public string PickUp_Place {  get; set; }

        [Required]
        public string Arrival_Place { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Date { get; set; }
    }
}
