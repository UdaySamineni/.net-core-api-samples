using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioning.Config.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void UseCustomSwaggerApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Versioning Project",
                    Version = "v1"
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "API Versioning Project",
                    Version = "v2"
                });
                options.SwaggerDoc("v3", new OpenApiInfo
                {
                    Title = "API Versioning Project",
                    Version = "v3"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.DocumentFilter<SecurityRequirementsDocumentFilter>();
                options.OperationFilter<RemoveVersionFromParameter>();
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                options.DocInclusionPredicate((docName, description) =>
                {
                    if (!description.TryGetMethodInfo(out var methodInfo)) return false;
                    var versions = methodInfo.DeclaringType?
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);
                    return versions != null && versions.Any(v => $"v{v}" == docName);
                });

            });
        }

        public static void UseCustomSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("../swagger/v1/swagger.json", "v1");
                s.SwaggerEndpoint("../swagger/v2/swagger.json", "v2");
                s.SwaggerEndpoint("../swagger/v3/swagger.json", "v3");
            });
        }
    }
}