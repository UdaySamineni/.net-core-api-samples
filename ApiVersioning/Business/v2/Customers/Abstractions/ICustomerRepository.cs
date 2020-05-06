using System.Collections.Generic;
using Models.v2;

namespace Business.v2.Customers.Abstractions
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
    }
}