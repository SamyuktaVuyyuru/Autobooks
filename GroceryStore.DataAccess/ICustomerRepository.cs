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
         List<Customer> GetAll();
         Customer GetById(int id);
         bool Update(int id, string value);
         bool Delete(int id);
         bool Add(string value);

    }
}
