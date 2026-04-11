namespace GoldenMind.Models
{
    public class CareGaver
    {
        public int Id { set; get; } 
        public string Name { set; get; }
        public string Address { set; get; }
        public string Password { set; get; }
        public bool Online { set; get; } = false;
        public string Education { set; get; }
        public string Phone { set; get; }
        public DateTime LastActive { set; get; }
        public ICollection<User> ?patients { get; set; }
    }
}
