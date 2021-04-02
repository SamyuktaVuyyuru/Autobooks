using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStore.Models;
using GroceryStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ICustomerService customerService;
        public ValuesController(ICustomerService CustomerService)
        {
            customerService = CustomerService;
        }
        
        /// <summary>
        /// Controller call to get all customer records
        /// </summary>
        /// <returns>List of customers</returns>
        // GET api/values
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return customerService.GetAll();
        }

        /// <summary>
        /// Controller call to return a customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A customer by Id input</returns>
        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return customerService.GetById(id);
        }

        /// <summary>
        /// Controller call to a new customer record
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            customerService.Add(value);
        }

        /// <summary>
        /// Controller call to update a customer record by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
             customerService.Update(id, value);
        }

        /// <summary>
        /// Controller call to delete a customer record by Id
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             customerService.Delete(id);
        }
    }
}
