using System.Collections.Generic;
using Models.v1._1;

namespace Business.v1._1.Customers.Abstractions
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomers();
    }
}