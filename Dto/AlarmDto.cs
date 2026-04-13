using GoldenMind.Models;

namespace GoldenMind.Dto
{
    public class AlarmDto
    {
        public DateTime DateTime { set; get; }
        public int UserId { set; get; }
        public bool Repeat { set; get; }
        public bool Discard { set; get; }
    }
}
