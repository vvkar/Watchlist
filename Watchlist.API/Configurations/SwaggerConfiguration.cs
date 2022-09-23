using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Neobank.Test.API.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Neobank.Test API",
                    Description = "Test task API connected to IMDB API",
                    Contact = new OpenApiContact()
                    {
                        Name = "email",
                        Email = "v.v.karankevich@gmail.com"
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                setup.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, xmlFilename)); ;
            });
        }
    }
}
