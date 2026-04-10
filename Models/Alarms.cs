namespace GoldenMind.Models
{
    public class Alarms
    {
        public int Id { set; get; }
        public DateTime DateTime { set; get; }
        public User User { set; get; }
        public DoctorModel ? Doctor { set; get; }
        public bool Repeat { set; get; }
        public bool Discard { set; get; }
    }
}
