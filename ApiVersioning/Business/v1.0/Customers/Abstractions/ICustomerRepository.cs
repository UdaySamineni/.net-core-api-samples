using System.Collections.Generic;
using Models.v1._0;

namespace Business.v1._0.Customers.Abstractions
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
    }
}