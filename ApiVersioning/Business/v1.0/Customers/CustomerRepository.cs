using System.Collections.Generic;
using Business.v1._0.Customers.Abstractions;
using Data.v1._0.Customers.Abstractions;
using Models.v1._0;

namespace Business.v1._0.Customers
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