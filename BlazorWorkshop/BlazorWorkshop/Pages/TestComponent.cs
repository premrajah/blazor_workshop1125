using BlazorWorkshop.Data;
using BlazorWorkshop.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWorkshop.Pages
{
    public class TestComponentCode : ComponentBase
    {

        [Parameter]
        public List<Customer> Customers { get; set; } = new List<Customer>();

        [Parameter]
        public EventCallback<Customer> CustomerSelectEvent { get; set; }

        [Parameter]
        public Customer SelectedCustomer { get; set; }

        [Parameter]
        public EventCallback<int> CustomerResetEvent { get; set; }

        [Parameter]
        public EventCallback<string> AddCustomerEvent { get; set; }

        public string NewCustomerName = "";




        public async Task CustomerSelected(ChangeEventArgs args)
        {
            SelectedCustomer = (from x in Customers
                                where x.CustomerId.ToString() == args.Value.ToString()
                                select x).First();

            await CustomerSelectEvent.InvokeAsync(SelectedCustomer);

        }

        public async Task ResetButtonClicked()
        {
            await CustomerResetEvent.InvokeAsync(SelectedCustomer.CustomerId);
        }

        public async Task CustomerAdding()
        {
            await AddCustomerEvent.InvokeAsync(NewCustomerName);
            NewCustomerName = "";
        }

        
    }
}
