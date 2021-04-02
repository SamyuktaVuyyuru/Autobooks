using GroceryStore.Models;
using GroceryStore.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GroceryStore.DataAccess
{
    /// <summary>
    /// CustomerRepository class for service calls. 
    /// Handles the business logic
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private IDataStore dataStore;

        public CustomerRepository(IDataStore DataStore)
        {
            dataStore = DataStore;
        }
        /// <summary>
        /// Initiates a call to the datastore that holds the backend logic to read/write the json file to get the list of customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetAll()
        {
            return  dataStore.GetRawData();
        }

        /// <summary>
        /// Returns a single customer record by iterating through all records fetched from Datastore
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer</returns>
        public Customer GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Iterate through list of customers to identify the record to be updated by Id, modify and update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public bool Update(int id, string value)
        {
            bool isUpdated = false;
            var customers = GetAll();
            var existingData = customers.FirstOrDefault(x => x.Id == id);

            if (existingData != null)
            {
                existingData.Name = value;
                isUpdated = dataStore.UpdateRawData(customers); //update method
            }
            return isUpdated;
        }

        /// <summary>
        /// Deletes a customer record by iterating through list of customers
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            var customers = GetAll();
            var existingData = customers.FirstOrDefault(x => x.Id == id);
            customers.Remove(existingData);
           return dataStore.UpdateRawData(customers);
        }
        
        /// <summary>
        /// Add a customer by interating through the list of customers and incrementing to next available Id
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public bool Add(string value)
        {
            bool isAdded = false;
            var customers = GetAll();
            var lastCust = customers.OrderByDescending(x => x.Id).FirstOrDefault();
            if(lastCust != null)
            {
                customers.Add(new Customer { Id = ++lastCust.Id, Name = value });
               isAdded =  dataStore.UpdateRawData(customers);
            }
            return isAdded;
        }

    }
}
