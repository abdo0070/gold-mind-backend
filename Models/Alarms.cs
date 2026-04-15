namespace GoldenMind.Models
{
    public class Alarms
    {
        public int Id { set; get; }
        public DateTime DateTime { set; get; }
        public int UserId { set; get; }
        public Patient ? Patient{ set; get; }
        public bool Repeat { set; get; }
        public bool Discard { set; get; }
    }
}
