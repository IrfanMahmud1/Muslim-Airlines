﻿using System.ComponentModel.DataAnnotations;

namespace AirlineReservationWebApplication.Models
{
    public class AircraftViewModel
    {
        [Key]
        public int Aircraft_Model { get; set; }

        [Required]
        public string Aircraft_Category { get; set; }

        [Required]
        public int Seat_Capacity { get; set; }

        [Required]
        public string Aircraft_Type { get; set; }
        [Required]
        public bool Availability { get;set; } 
    }
}
