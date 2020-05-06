using Business.v1.Customers;
using Business.v1.Customers.Abstractions;
using Data.v1.Customers;
using Data.v1.Customers.Abstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiVersionServiceCollectionV1
    {
        public static IServiceCollection AddApiVersioningServiceCollectionV1(this IServiceCollection services)
        {
            services.AddScoped<ICustomerDataStore, CustomerDataStore>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}