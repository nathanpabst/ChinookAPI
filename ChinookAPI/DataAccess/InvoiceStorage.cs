using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinookAPI.DataAccess
{
    public class InvoiceStorage
    {
        private const string ConnectionString = "Server=(local);Database=ChinookAPI;Trusted_Connection=True;";
        public Invoice GetById(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {

            }
        }
    }
}
