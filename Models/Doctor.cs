namespace GoldenMind.Models
{
    public class DoctorModel
    {
        public ICollection<User> patients { get; set; }
        public int Id { set; get; } 
        public string Name { set; get; }
        public string Address { set; get; } 
        public DateTime lastActive { set; get; }
        
    }
}
