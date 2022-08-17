using Microsoft.EntityFrameworkCore;

namespace CoreApiDemo.Entities
{
    public class NetCoreApiDemoContext : DbContext
    {
        public NetCoreApiDemoContext(DbContextOptions<NetCoreApiDemoContext> options)
            : base(options)
        { }

    }
}
