using System;
using System.Collections.Generic;
using Data.v1.Customers.Abstractions;
using Models.v1;

namespace Data.v1.Customers
{
    public class CustomerDataStore: ICustomerDataStore
    {
        public List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Test 1",
                    Phone = "(234) 456-3455",
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            Id = 1,
                            OrderNumber = 123,
                            OrderDate = DateTime.Today
                        }
                    }
                }
            };
        }
    }
}