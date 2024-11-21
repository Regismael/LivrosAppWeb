using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace LivrosApp.API.Configurations
{
    public class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LivrosApp",
                    Description = "Site: LivrosIsma.com.br",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "LivrosApp Support",
                        Url = new Uri("https://LivrosIsma.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "© 2024 LivrosApp",
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LivrosApp v1");
                c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root (e.g., http://localhost:5000/)
            });
        }
    }
}
