using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions
{
    public static class CommonServiceExtension
    {
        public static IServiceCollection AddCommonService(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining(assembly);

            services.AddAutoMapper(assembly); 

            return services;
        }
    }
}
