using FabricMethodApi.Infrastructure.Configuration;
using FabricMethodApi.Infrastructure.Service;

namespace FabricMethodApi.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<NotificationSettings>(
                configuration.GetSection("NotificationSettings"));

            services.AddScoped<EmailNotificationService>();
            services.AddScoped<SmsNotificationService>();
            services.AddScoped<SystemNotificationService>();
            services.AddScoped<NotificationManager>();

            return services;
        }
    }
}
