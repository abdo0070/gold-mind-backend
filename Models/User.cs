using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace GoldenMind.Models
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Level { get; set; }
        public int DoctorId { get; set; }
        public ICollection<Alarms> ? alarms { get; set; }
        public DoctorModel ? Doctor { get; set; }

    }
}
