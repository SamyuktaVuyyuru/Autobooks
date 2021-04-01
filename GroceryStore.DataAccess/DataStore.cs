using GroceryStore.Models;
using GroceryStore.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.DataAccess
{
    public class DataStore : IDataStore
    {   /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a list of customer records</returns>
        public List<Customer> GetRawData()
        {
            List<Customer> customers = new List<Customer>();
            using (StreamReader r = new StreamReader("database.json"))
            {
                var rawData = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<RawData>(rawData);
                if(data != null)
                {
                    customers = data.Customers;
                }
            }
            return customers;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customers"></param>
        /// <returns>Returns true after a customer record is updated</returns>
        public bool UpdateRawData(List<Customer> customers)
        {
            var rawData = new RawData() { Customers = customers };
            File.WriteAllText("database.json", JsonConvert.SerializeObject(rawData));
            return true;
        }
    }
}
