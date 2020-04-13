using BlazorWorkshop.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWorkshop.Pages
{
    public class IndexCode : ComponentBase
    {
        public string DisplayMessage = "";

        public void CustomerSelected(Customer customer)
        {
            DisplayMessage = $"Event Raised. Customer Selected: {customer.Name}";
        }

        public List<Customer> Customers = new List<Customer>();

        protected override void OnInitialized()
        {
            Customers.Add(new Customer { CustomerId = 1, Name = "Isadora Jarr" });
            Customers.Add(new Customer { CustomerId = 2, Name = "Ben Slackin" });
            Customers.Add(new Customer { CustomerId = 3, Name = "Doo Fuss" });
        }
    }
}
