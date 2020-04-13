using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWorkshop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var Customers = new List<Customer>();
            Customers.Add(new Customer { CustomerId = 1, Name = "Isadora Jarr" });
            Customers.Add(new Customer { CustomerId = 2, Name = "Ben Slackin" });
            Customers.Add(new Customer { CustomerId = 3, Name = "Doo Fuss" });

            return Customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
