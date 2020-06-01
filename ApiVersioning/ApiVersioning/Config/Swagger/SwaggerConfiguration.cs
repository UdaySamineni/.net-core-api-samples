using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ApiVersioning.Config.Swagger
{
    public static class SwaggerConfiguration
    {
        public static void UseCustomSwaggerApi(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });
            services.AddApiVersioningServiceCollectionV1();
            services.AddApiVersioningServiceCollectionV2();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "API Versioning Project",
                    Version = "v1"
                });
                options.SwaggerDoc("v2", new Info
                {
                    Title = "API Versioning Project",
                    Version = "v2"
                });
                options.SwaggerDoc("v3", new Info
                {
                    Title = "API Versioning Project",
                    Version = "v3"
                });
                options.OperationFilter<RemoveVersionFromParameter>();
                options.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
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