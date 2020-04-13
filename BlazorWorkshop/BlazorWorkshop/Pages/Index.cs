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
        public List<Customer> Customers = new List<Customer>();

        public Customer SelectedCustomer;

        public void CustomerSelected(Customer customer)
        {
            SelectedCustomer = customer;
        }


        protected override async Task OnInitializedAsync()
        {
            Customers = await CustomerService.GetAllCustomers();
        }
    }
}
