using Microsoft.Extensions.Options;

namespace CatalogService.Api.Options
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddOptionsExt(this IServiceCollection services)
        {
            services.AddOptions<MongoOptions>().BindConfiguration(nameof(MongoOptions)).ValidateDataAnnotations().ValidateOnStart();

            services.AddSingleton<MongoOptions>(sp => sp.GetRequiredService<IOptions<MongoOptions>>().Value);
            
            return services;
        }
    }
}
