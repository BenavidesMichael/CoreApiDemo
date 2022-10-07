using Microsoft.EntityFrameworkCore;

namespace CoreApiDemo.Entities.Configuration.Conventions
{
    public static class DateTimeConvention
    {
        public static void Convert(this ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }
    }
}
