using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.Models
{
    public class Invoice
    {
        public string SalesAgent { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public string BillingAddress { get; set; }
        public string Country { get; set; }
        public decimal InvoiceAmt { get; set; }
        public decimal InvoiceDate { get; set; }
    }
}
