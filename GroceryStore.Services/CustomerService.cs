using GroceryStore.DataAccess;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Services
{
    /// <summary>
    /// CustomerService class to handle the presentation logic
    /// </summary>
    public class CustomerService: ICustomerService
    {
        private ICustomerRepository customerRepository;

        /// <summary>
        /// Constructor to initialize the CustomerRepository
        /// </summary>
        /// <param name="CustomerRepository"></param>
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            customerRepository = CustomerRepository;
        }

        /// <summary>
        /// Returns all customers
        /// </summary>
        /// <returns>List of Customers</returns>
        public List<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }

        /// <summary>
        /// Returns a customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Customer</returns>
        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);

        }

        /// <summary>
        /// Updates a customer and returns true on successful update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public bool Update(int id, string value)
        {
           return  customerRepository.Update(id,value);
        }

        /// <summary>
        /// Deletes a customer by Id and returns true on success
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool Delete(int id)
        {
            return customerRepository.Delete(id);
        }

        /// <summary>
        /// Adds a new customer and returns true on success
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        public bool Add(string value)
        {
           return customerRepository.Add(value);
        }
    }
}
