using CoreApiDemo.Infrastructure;
using System.Reflection;
using System.Text.Json.Serialization;

namespace CoreApiDemo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBase(Configuration);
            services.AddIdentity(Configuration);
            services.AddHttpContextAccessor();
            services.AddCorsExtention();
            services.AddRepositories();
            services.GetAppSettingsValues(Configuration);
            services.AddSwagger($"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            services.AddControllers()
                .AddJsonOptions(opt => {
                    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.ApplySwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
