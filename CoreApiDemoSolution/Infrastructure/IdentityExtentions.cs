using CoreApiDemo.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CoreApiDemo.Infrastructure
{
    public static class IdentityExtentions
    {
        public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddIdentity<Person, IdentityRole>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<NetCoreApiDemoContext>()
             .AddDefaultTokenProviders();


            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.SaveToken = true;
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWTSetting:Issuer"],
                    ValidAudience = Configuration["JWTSetting:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSetting:SecretKeyToken"])),
                    ClockSkew = TimeSpan.Zero
                };
                opt.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}
