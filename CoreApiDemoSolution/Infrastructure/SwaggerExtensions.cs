using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CoreApiDemo.Infrastructure
{
    public static class SwaggerExtensions
    {
        private const string title = "Net Core Api Demo";
        private const string version = "v1";
        private const string securityScheme = "Bearer";

        public static IServiceCollection AddSwagger(this IServiceCollection services, string xmlFileName)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = title, Version = version });
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                c.IncludeXmlComments(xmlPath);

                // Authorization Sawagger
                c.AddSecurityDefinition(securityScheme, new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Description = "Please enter token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = securityScheme,
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = securityScheme
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }


        public static void ApplySwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger()
               .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", title));
        }

    }

}
