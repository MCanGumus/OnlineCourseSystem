using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    public static class VersionExtension
    {
        public static IServiceCollection AddVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1.0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
                //options.ApiVersionReader = ApiVersionReader.Combine(new HeaderApiVersionReader(), new QueryStringApiVersionReader(), new UrlSegmentApiVersionReader());


            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'V";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }

        public static ApiVersionSet AddVersionSetExtension(this WebApplication app)
        {
            var appVersionSets = app.NewApiVersionSet()
                .HasApiVersion(new ApiVersion(1, 0))
                .HasApiVersion(new ApiVersion(1, 2))
                .HasApiVersion(new ApiVersion(2, 0))
                .ReportApiVersions()
                .Build();

            return appVersionSets;
        }
    }
}
