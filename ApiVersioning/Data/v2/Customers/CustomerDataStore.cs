using System;
using System.Collections.Generic;
using Data.v2.Customers.Abstractions;
using Models.v2;

namespace Data.v2.Customers
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
                    Address = new Address
                    {
                        Id = 1,
                        AddressLine = "815 Grant Ave",
                        City = "Charleston",
                        State = "IL",
                        Zip = 345694
                    },
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