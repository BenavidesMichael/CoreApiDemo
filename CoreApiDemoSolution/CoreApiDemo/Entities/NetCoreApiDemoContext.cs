using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreApiDemo.Entities
{
    public class NetCoreApiDemoContext : IdentityDbContext
    {
        public NetCoreApiDemoContext(DbContextOptions<NetCoreApiDemoContext> options)
            : base(options)
        { }

    }
}
