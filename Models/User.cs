using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Email { get; set; }
        public string Education { get; set; }

        public int Age { get; set; }
        public int Level { get; set; }
        public int CareGaverId { get; set; }
        public ICollection<Alarms>? alarms { get; set; }
        public CareGaver? careGaver{ get; set; }

    }
}
