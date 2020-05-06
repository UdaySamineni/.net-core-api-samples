using System.Collections.Generic;
using Business.v2.Customers.Abstractions;
using Data.v2.Customers.Abstractions;
using Models.v2;

namespace Business.v2.Customers
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ICustomerDataStore _customerDataStore;

        public CustomerRepository(ICustomerDataStore customerDataStore)
        {
            _customerDataStore = customerDataStore;
        }

        public IList<Customer> GetCustomers()
        {
            return _customerDataStore.GetCustomers();
        }
    }
}