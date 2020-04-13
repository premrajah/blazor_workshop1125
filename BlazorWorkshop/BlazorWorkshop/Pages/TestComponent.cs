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
        public Customer SelectedCustomer;

        [Parameter]
        public List<Customer> Customers { get; set; } = new List<Customer>();

        [Parameter]
        public EventCallback<Customer> CustomerSelectEvent { get; set; }


        public async Task CustomerSelected(ChangeEventArgs args)
        {
            SelectedCustomer = (from x in Customers
                                where x.CustomerId.ToString() == args.Value.ToString()
                                select x).First();

            await CustomerSelectEvent.InvokeAsync(SelectedCustomer);

        }
    }
}
