using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWorkshop.Pages
{
    public class CounterCode : ComponentBase
    {
        public int currentCount { get; set; }

        public void IncrementCount()
        {
            currentCount++;
        }
    }
}
