﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace RunGroupWebApp.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
