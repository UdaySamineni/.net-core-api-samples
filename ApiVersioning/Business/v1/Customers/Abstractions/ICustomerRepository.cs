using System.Collections.Generic;
using Models.v1;

namespace Business.v1.Customers.Abstractions
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
    }
}