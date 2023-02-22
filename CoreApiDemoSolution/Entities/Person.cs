using Microsoft.AspNetCore.Identity;

namespace CoreApiDemo.Entities
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
