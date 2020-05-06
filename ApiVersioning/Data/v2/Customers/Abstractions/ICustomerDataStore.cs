using System.Collections.Generic;
using Models.v2;

namespace Data.v2.Customers.Abstractions
{
    public interface ICustomerDataStore
    {
        List<Customer> GetCustomers();
    }
}