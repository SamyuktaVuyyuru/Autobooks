using GroceryStore.Models;
using GroceryStore.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private IDataStore dataStore;

        public CustomerRepository(IDataStore DataStore)
        {
            dataStore = DataStore;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns all customer records</returns>
        public List<Customer> GetAll()
        {
            return  dataStore.GetRawData();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a single customer record by Id</returns>
        public Customer GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>Updates a single customer</returns>
        public bool Update(Customer customer)
        {
            var customers = GetAll();
            var existingData = customers.FirstOrDefault(x => x.Id == customer.Id);

            if (existingData != null)
            {
                existingData.Name = customer.Name;
                dataStore.UpdateRawData(customers);
            }

            return true;
        }

        public void Update(int id, string value)
        {
            var customers = GetAll();
            var existingData = customers.FirstOrDefault(x => x.Id == id);

            if (existingData != null)
            {
                existingData.Name = value;
                dataStore.UpdateRawData(customers); //update method
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes a customer record by Id</returns>
        public bool Delete(int id)
        {
            var customers = GetAll();
            var existingData = customers.FirstOrDefault(x => x.Id == id);
            customers.Remove(existingData);
            dataStore.UpdateRawData(customers);
            return true;
        }
        

        public void Add(string value)
        {
            var customers = GetAll();
            var lastCust = customers.OrderByDescending(x => x.Id).FirstOrDefault();
            if(lastCust != null)
            {
                customers.Add(new Customer { Id = ++lastCust.Id, Name = value });
                dataStore.UpdateRawData(customers);
            }
        }

    }
}
