using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class Invoice
    {
        public decimal InvoiceAmt { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public string SalesAgent { get; set; }
    }
}
