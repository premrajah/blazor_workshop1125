﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorWorkshop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlazorWorkshop.Controllers
{

    

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        // local saving (cheating)
        private List<Customer> Customers;
        private string customerDataFile = "";

        public CustomerController()
        {
            LoadData();
        }

        private void LoadData()
        {
            customerDataFile = Environment.CurrentDirectory + @"\customers.json";
            if(!System.IO.File.Exists(customerDataFile))
            {
                Customers = GetAllCustomers();
                SaveData();
            }
            else
            {
                var json = System.IO.File.ReadAllText(customerDataFile);
                Customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }
        }

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(Customers);
            System.IO.File.WriteAllText(customerDataFile, json);
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return Customers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "Get")]
        public Customer Get(int id)
        {

            return (from x in Customers
                    where x.CustomerId == id
                    select x).FirstOrDefault();
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] Customer value)
        {
            Customers.Add(value);
            SaveData();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer value)
        {
            Customers[Customers.FindIndex(x => x.CustomerId == id)] = value;
            SaveData();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customer = Customers[Customers.FindIndex(x => x.CustomerId == id)];
            Customers.Remove(customer);
            SaveData();
        }

        private List<Customer> GetAllCustomers()
        {
            if(Customers == null)
            {
                Customers = new List<Customer>();

                Customers.Add(new Customer { CustomerId = 1, Name = "Isadora Jarr" });
                Customers.Add(new Customer { CustomerId = 2, Name = "Ben Slackin" });
                Customers.Add(new Customer { CustomerId = 3, Name = "Doo Fuss" });
                Customers.Add(new Customer { CustomerId = 4, Name = "Hugh Jass" });
                Customers.Add(new Customer { CustomerId = 5, Name = "Donatella Nawan" });
                Customers.Add(new Customer { CustomerId = 6, Name = "Pykop Andropov" });
            }
            
            return Customers;
        }



    }
}
