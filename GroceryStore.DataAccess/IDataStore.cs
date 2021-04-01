using GroceryStore.Models;
using System;
using System.Collections.Generic;

namespace GroceryStore.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataStore
    {
        List<Customer> GetRawData();
        bool UpdateRawData(List<Customer> customers);
    }
}
