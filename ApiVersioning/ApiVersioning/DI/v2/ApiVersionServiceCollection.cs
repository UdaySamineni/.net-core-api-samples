using Business.v2.Customers;
using Business.v2.Customers.Abstractions;
using Data.v2.Customers;
using Data.v2.Customers.Abstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiVersionServiceCollectionV2
    {
        public static IServiceCollection AddApiVersioningServiceCollectionV2(this IServiceCollection services)
        {
            services.AddScoped<ICustomerDataStore, CustomerDataStore>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}