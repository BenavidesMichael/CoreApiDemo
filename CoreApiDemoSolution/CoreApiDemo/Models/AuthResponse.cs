using System;

namespace CoreApiDemo.Models
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public DateTime Expires { get; set; }
    }
}
