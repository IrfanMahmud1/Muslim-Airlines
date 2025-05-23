﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineReservationWebApplication.Areas.Admin.Models
{
    public class FlightViewModel
    {
        [Key]
        public int Flight_Id { get; set; }

        [Required]
        public string Flight_Name { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Departure_Date { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Arrival_Date { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Departure_Time { get; set; }

        [DataType(DataType.Time)]
        public TimeOnly Arrival_Time { get; set; }

        [Required]
        public string Departure_Place {  get; set; }

        [Required]
        public string Arrival_Place {  get; set; }

        public int Total_Seats { get; set; }

        public int Booked_Seats { get; set; }

        [Required]
        public int Aircraft_Id { get; set; }

        [Required]
        public string Flight_Type { get; set; }

        [Required]
        public string Flight_Status { get; set; } = "Not scheduled";
        public decimal B_Price { get; set; }
        public decimal E_Price { get; set; }
        public decimal FC_Price { get; set; }
        public int Business {  get; set; }

        public int Economy { get; set; }

        public int FirstClass { get; set; }

        [NotMapped]
        public List<(string, int,int)>? AllAircrafts { get; set; }
    }
}
