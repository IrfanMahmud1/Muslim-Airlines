using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Models
{
    public class PassengerViewModel
    {
        [Key]
        public int Passenger_ID {  get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set;}
        [Required]

        public string Gender { get; set; }
        [Required]
        public int Passport {  get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public int Mobile { get; set; }
        [Required]
        public int Nid { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public virtual RegisterViewModel registerViewModel { get; set; }

    }
}
