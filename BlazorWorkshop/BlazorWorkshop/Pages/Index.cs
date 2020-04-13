using BlazorWorkshop.Data;
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

        protected override async Task OnInitializedAsync()
        {
            Customers = await CustomerService.GetAllCustomers();
        }
    }
}
