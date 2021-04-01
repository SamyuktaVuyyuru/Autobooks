using GroceryStore.Models;
using System;
using System.Collections.Generic;

namespace GroceryStore.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         List<Customer> GetAll();
         Customer GetById(int id);
         bool Update(Customer customer);
         void Update(int id, string value);
         bool Delete(int id);
        void Add(string value);

    }
}
