using System;
using System.Collections.Generic;

namespace GroceryStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class RawData
    {
        public List<Customer> Customers { get; set; }
    }
}
