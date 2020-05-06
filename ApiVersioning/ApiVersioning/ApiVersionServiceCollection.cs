using Business.v1._0.Customers;
using Business.v1._0.Customers.Abstractions;
using Data.v1._0.Customers;
using Data.v1._0.Customers.Abstractions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApiVersionServiceCollection
    {
        public static IServiceCollection AddApiVersioningServiceCollection(this IServiceCollection services)
        {
            // v1.0
            services.AddScoped<ICustomerDataStore, CustomerDataStore>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            // v1.1
            services.AddScoped<Data.v1._1.Customers.Abstractions.ICustomerDataStore, Data.v1._1.Customers.CustomerDataStore>();
            services.AddScoped<Business.v1._1.Customers.Abstractions.ICustomerRepository, Business.v1._1.Customers.CustomerRepository>();

            return services;
        }
    }
}