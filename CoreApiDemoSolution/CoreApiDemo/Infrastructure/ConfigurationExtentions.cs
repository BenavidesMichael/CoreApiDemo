using CoreApiDemo.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoreApiDemo.Infrastructure
{
    public static class ConfigurationExtentions
    {
        public static string GetDefaultConnectionString(this IConfiguration Configuration, string name)
        {
            return Configuration.GetConnectionString(name);
        }


        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<NetCoreApiDemoContext>(options
                    => options.UseSqlServer(Configuration.GetDefaultConnectionString("DemoApi"), 
                                            sqlserver => sqlserver.UseNetTopologySuite()));
            return services;
        }


        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(opt => opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SettingsConfig:SecretKeyToken"]))
                    });

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<NetCoreApiDemoContext>()
                    .AddDefaultTokenProviders();
            return services;
        }
    }
}
