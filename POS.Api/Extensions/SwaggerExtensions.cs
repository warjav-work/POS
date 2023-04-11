using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace POS.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSawgger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "POS API",
                Version = "v1",
                Description = "Punto de Venta API 2023",
                TermsOfService = new Uri("https://opensource.org/license/gpl-1-0/"),
                Contact = new OpenApiContact
                {
                    Name = "WAR TECH S.R.L.",
                    Email = "warjav.work@gmail.com",
                    Url = new Uri("http://warjav.work.es")
                },
                License = new OpenApiLicense
                {
                    Name = "Used under LICX",
                    Url = new Uri("https://opensource.org/license/gpl-1-0/"),

                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "JWT Bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme

                    }
                };
                x.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[]{} }

                });
            });
            return services;
        }
    }
}
