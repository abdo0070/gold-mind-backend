namespace GoldenMind.Models
{
    public class DoctorModel
    {
        public int Id { set; get; } 
        public string Name { set; get; }
        public string Address { set; get; } 
        public DateTime lastActive { set; get; }
        public ICollection<User> ?patients { get; set; }
    }
}
