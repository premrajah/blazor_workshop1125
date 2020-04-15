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

        public async Task CustomerResetting(int CustomerId)
        {
            var originalCustomer = await CustomerService.GetCustomer(CustomerId);

            if (originalCustomer != null)
            {
                // replace the customer and reset the selected customer
                Customers[Customers.FindIndex(x => x.CustomerId == CustomerId)] = originalCustomer;
                SelectedCustomer = originalCustomer;
            }
        }

        public async Task CustomerAdding(string Name)
        {
            if (!string.IsNullOrEmpty(Name))
            {
                var highest = Customers.OrderByDescending(i => i.CustomerId).Take(1).First();
                var customer = new Customer()
                {
                    CustomerId = highest.CustomerId + 1,
                    Name = Name
                };

                await CustomerService.AddCustomer(customer);
                Customers = await CustomerService.GetAllCustomers();
            }
            else
            {
                return;
            }
        }

        public async Task CustomerUpdating(Customer Customer)
        {
            await CustomerService.UpdateCustomer(Customer);
            Customers = await CustomerService.GetAllCustomers();
        }
    }
}
