using Serilog;
using Serilog.Formatting.Json;
using System.Reflection;

namespace CoreApiDemo.Infrastructure
{
    public static class SerilogExtention
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog((context, lc) =>
                    lc.MinimumLevel.Warning()
                      .WriteTo.Console(new JsonFormatter())
                      .WriteTo.File(new JsonFormatter(), Path.Combine(AppContext.BaseDirectory, $"Logs/log-{DateTime.Now.ToShortDateString()}-{Assembly.GetExecutingAssembly().GetName().Name}.txt"))
                );
        }
    }
}
