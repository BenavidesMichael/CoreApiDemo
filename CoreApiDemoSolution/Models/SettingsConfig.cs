namespace CoreApiDemo.Models
{
    public class JWTOptions
    {
        public const string JWTSetting = "JWTSetting";
        public string SecretKeyToken { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
