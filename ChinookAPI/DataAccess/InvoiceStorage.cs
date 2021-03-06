﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookAPI.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace ChinookAPI.DataAccess
{
    public class InvoiceStorage
    {
        static List<Invoice> _invoices = new List<Invoice>();
        static List<SalesAgent> _agents = new List<SalesAgent>();

        private readonly string ConnectionString;

        public InvoiceStorage(IConfiguration config)
        {
            ConnectionString = config.GetSection("ConnectionString").Value;
        }

        //5) Provide a new endpoint to UPDATE an Employee's name with a parameter 
        //for Employee Id and new name
        public bool UpdateEmployeeName(int employeeId, string firstName, string lastName)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sql = "UPDATE Employee SET FirstName = @firstName, LastName = @lastName WHERE EmployeeId = @employeeId";
                var result5 = connection.Execute(sql, new { EmployeeId = employeeId, FirstName = firstName, LastName = lastName });
                return result5 == 1;
            }
        }

        //4) Provide a new endpoint to INSERT a new invoice with parameters 
        //for customerid and billing address
        public bool PostInvoice(int customerId, string billingAddress )
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open(); 
                string sql = "INSERT INTO Invoice(CustomerId, BillingAddress, Total, InvoiceDate) VALUES(@CustomerId, @BillingAddress, 42, GETDATE())";
                var result4 = connection.Execute(sql, new { CustomerId = customerId, BillingAddress = billingAddress });
                return result4 == 1;
            }
        }

        //3) Looking at the InvoiceLine table, provide an endpoint that COUNTs 
        //the number of line items for an Invoice with a parameterized Id from user input

        public int GetLineItems(int id)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string lineItems = "SELECT COUNT(*) FROM InvoiceLine WHERE InvoiceId = @id";
                return connection.QueryFirst<int>(lineItems, new { id = id });
            }

        }

        //2) USING DAPPER..Provide an endpoint that shows the Invoice Total, Customer name, Country and Sale Agent name for all invoices.
        public List<Invoice> GetInvoices()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result2 = connection.Query<Invoice>(@"SELECT 
                                           SalesAgent = e.FirstName + ' ' + e.LastName,
                                           CustomerName = c.FirstName + ' ' + c.LastName,
                                           Country = i.BillingCountry,
                                           InvoiceAmt = i.Total
                                           FROM Employee as e
                                           inner join Customer as c ON c.SupportRepId = e.EmployeeId
                                           inner join Invoice as i ON i.CustomerId = c.CustomerId");

                return result2.ToList();
            }
        }

        //1) Provide an endpoint that shows the invoices associated with each sales agent. The result should include the Sales Agent's full name.
        public List<SalesAgent> GetInvoicesByRep()
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var result1 = connection.Query<SalesAgent>(@"SELECT                                
	                                        AgentName = e.FirstName + ' ' + e.LastName,
                                            i.*
                                        FROM Employee as e
                                            inner join Customer as c ON c.SupportRepId = e.EmployeeId
                                            inner join Invoice as i ON i.CustomerId = c.CustomerId");
                return result1.ToList();
                
            }
        }

    }
}
