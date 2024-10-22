using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Areas.Admin.Models
{
    public class PassengerViewModel
    {
        [Key]
        public int Passenger_ID {  get; set; }

        [Required]
        public string First_Name { get; set; }

        [Required]
        public string Last_Name { get; set;}

        //[Required]
        public string Title { get; set; }

        public string Gender { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string Passport {  get; set; }

        public DateOnly Date_of_Birth { get; set; }

        [Required]
        public DateOnly PassportExpiryDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Mobile { get; set; }

        [Required]
        public string Nid { get; set; }

        [Required]
        public string Country { get; set; } = "Bangladesh";

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int User_Id { get; set; }

        //public bool Is_Approved { get; set; }
        
        [NotMapped]
        public List<(string,int)>? AllUsers { get; set; }

    }
}
