using System.Collections.Generic;
using Models.v1._1;

namespace Data.v1._1.Customers.Abstractions
{
    public interface ICustomerDataStore
    {
        List<Customer> GetCustomers();
    }
}