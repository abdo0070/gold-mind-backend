namespace GoldenMind.Models
{
    public class Alarms
    {
        public DateTime dateTime { set; get; }
        public User user { set; get; }
        public bool repeat { set; get; }
        public bool discard { set; get; }
    }
}
