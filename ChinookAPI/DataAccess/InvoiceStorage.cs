using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookAPI.Models;
using System.Data.SqlClient;

namespace ChinookAPI.DataAccess
{
    public class InvoiceStorage
    {
        static List<Invoice> _invoices = new List<Invoice>();

        public List<Invoice> GetInvoices()
        {
            using (var connection = new SqlConnection("Server=(local);Database=ChinookAPI;Trusted_Connection=True;"))
            {

            }
            return _invoices;
        }
    }
}
