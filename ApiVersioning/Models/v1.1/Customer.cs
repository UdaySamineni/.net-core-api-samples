using System.Collections.Generic;

namespace Models.v1._1
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
    }
}