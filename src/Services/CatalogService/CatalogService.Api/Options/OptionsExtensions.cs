namespace CatalogService.Api.Options
{
    public static class OptionsExtensions
    {
        public static IServiceCollection AddOptionsExt(this IServiceCollection services)
        {
            services.AddOptions<MongoOptions>().BindConfiguration(nameof(MongoOptions)).ValidateDataAnnotations().ValidateOnStart();

            return services;
        }
    }
}
