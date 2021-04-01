using GroceryStore.DataAccess;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStore.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomerService: ICustomerService
    {
        private ICustomerRepository customerRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CustomerRepository"></param>
        public CustomerService(ICustomerRepository CustomerRepository)
        {
            customerRepository = CustomerRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAll()
        {
            return customerRepository.GetAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool Update(Customer customer)
        {
            return customerRepository.Update(customer);
        }

        public void Update(int id, string value)
        {
             customerRepository.Update(id,value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return customerRepository.Delete(id);

        }

        public void Add(string value)
        {
            customerRepository.Add(value);
        }
    }
}
