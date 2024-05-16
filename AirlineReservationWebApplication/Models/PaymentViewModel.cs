using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Models
{
    public class PaymentViewModel
    {
        [Key]
        public int Payment_Id { get; set; }

        [Required]
        public string Currency {  get; set; }

        [Required]
        public int Amount { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Payment_Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Payment_Time { get; set; }

        [Required]
        public int Reservation_Id { get; set; }

    }
}
