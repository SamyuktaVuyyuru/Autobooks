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
        
        // GET api/values
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return customerService.GetAll();
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return customerService.GetById(id);
            //return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            customerService.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
             customerService.Update(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
             customerService.Delete(id);
        }
    }
}
