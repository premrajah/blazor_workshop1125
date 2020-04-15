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
        public string MessageColor = "text-success";

        public List<Customer> Customers = new List<Customer>();

        public Customer SelectedCustomer;

        public void CustomerSelected(Customer customer)
        {
            SelectedCustomer = customer;
        }


        protected override async Task OnInitializedAsync()
        {
            try
            {
                Customers = await CustomerService.GetAllCustomers();
            }
            catch (Exception ex)
            {
                MessageColor = "text-danger";
                DisplayMessage = "Could not get customer data";

                Console.WriteLine($"Getting customer data {ex.Message}");
            }
        }

        public async Task CustomerResetting(int CustomerId)
        {
            try
            {
                var originalCustomer = await CustomerService.GetCustomer(CustomerId);

                if (originalCustomer != null)
                {
                    // replace the customer and reset the selected customer
                    Customers[Customers.FindIndex(x => x.CustomerId == CustomerId)] = originalCustomer;
                    SelectedCustomer = originalCustomer;

                    MessageColor = "text-success";
                    DisplayMessage = "Customer Reset.";
                }
                else
                {
                    MessageColor = "text-danger";
                    DisplayMessage = "Could not load existing customer";
                }

                
            }
            catch (Exception ex)
            {
                MessageColor = "text-danger";
                DisplayMessage = "Could not reset customer";
                Console.WriteLine($"Reseting customer {ex.Message}");
            }
        }

        public async Task CustomerAdding(Customer Customer)
        {

            try
            {
                var highest = Customers.OrderByDescending(i => i.CustomerId).Take(1).First();
                Customer.CustomerId = highest.CustomerId + 1;

                await CustomerService.AddCustomer(Customer);
                SelectedCustomer = Customer;

                Customers = await CustomerService.GetAllCustomers();

                MessageColor = "text-success";
                DisplayMessage = "Customer Added.";
            }
            catch (Exception ex)
            {
                MessageColor = "text-danger";
                DisplayMessage = "Could not add customer";
                Console.WriteLine($"Adding customer {ex.Message}");
            }
            
        }

        public async Task CustomerUpdating(Customer Customer)
        {
            try
            {
                await CustomerService.UpdateCustomer(Customer);
                Customers = await CustomerService.GetAllCustomers();

                MessageColor = "text-success";
                DisplayMessage = "Customer Updated.";
            }
            catch (Exception ex)
            {
                MessageColor = "text-danger";
                DisplayMessage = "Could not update customer";
                Console.WriteLine($"Updating customer {ex.Message}");
            }
        }

        public async Task CustomerDeleting(int CustomerId)
        {
            try
            {
                await CustomerService.DeleteCustomer(CustomerId);
                Customers = await CustomerService.GetAllCustomers();

                if(Customers.Count > 0)
                {
                    SelectedCustomer = Customers.First();
                }

                MessageColor = "text-success";
                DisplayMessage = "Customer Deleted.";
            }
            catch (Exception ex)
            {
                MessageColor = "text-danger";
                DisplayMessage = "Could not delete customer";
                Console.WriteLine($"Deleting customer {ex.Message}");
            }
        }
    }
}
