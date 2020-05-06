using System.Collections.Generic;
using Models.v1._0;

namespace Data.v1._0.Customers.Abstractions
{
    public interface ICustomerDataStore
    {
        List<Customer> GetCustomers();
    }
}