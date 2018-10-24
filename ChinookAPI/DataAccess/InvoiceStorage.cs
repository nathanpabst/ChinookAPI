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

        private const string ConnectionString = "Server=(local);Database=ChinookAPI;Trusted_Connection=True;";

        public List<Invoice> GetInvoices()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = @"SELECT 
                                            [Sales Agent] = e.FirstName + ' ' + e.LastName,
                                            [Customer Name] = c.FirstName + ' ' + c.LastName,
                                            [Country] = i.BillingCountry,
                                            [Invoice Amount] = i.Total
                                       FROM Employee as e
                                            inner join Customer as c ON c.SupportRepId = e.EmployeeId
                                            inner join Invoice as i ON i.CustomerId = c.CustomerId";
            var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var invoice = new Invoice
                    {
                        //the names in the square brackets should match the field names from the query results
                        SalesAgent = reader["Sales Agent"].ToString(),
                        CustomerName = reader["Customer Name"].ToString(),
                        Country = reader["Country"].ToString(),
                        InvoiceAmt = (decimal)reader["Invoice Amount"]
                    };
                    _invoices.Add(invoice);
                }
            }
            return _invoices;
        }
    }
}
