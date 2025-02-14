using AbstractFactoryApi.Infrastructure.Configuration;
using AbstractFactoryApi.Infrastructure.Factories.Interfaces;
using AbstractFactoryApi.Infrastructure.Factories;
using AbstractFactoryApi.Infrastructure.Service;

namespace AbstractFactoryApi.Infrastructure.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationServices(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.Configure<NotificationSettings>(
                configuration.GetSection("NotificationSettings"));
            // Register factories
            services.AddScoped<INotificationFactory, EmailNotificationFactory>();
            services.AddScoped<INotificationFactory, SmsNotificationFactory>();
            services.AddScoped<INotificationFactory, SystemNotificationFactory>();
            // Register message senders
            services.AddScoped<EmailMessageSender>();
            //here could be registered other message senders

            // Register notification service
            services.AddScoped<NotificationService>();

            return services;
        }
    }
}
