namespace GoldenMind.Auth
{
    public class JwtOptions
    {
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public string Key { get; set; }
    }
}
