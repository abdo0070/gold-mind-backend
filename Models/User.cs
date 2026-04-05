using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace GoldenMind.Models
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public DoctorModel ? Doctor { get; set; }

    }
}
