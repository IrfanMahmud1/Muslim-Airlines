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
        public DateTime Payment_Date { get; set; }

        [Required]
        public string Payment_For {  get; set; }

    }
}
