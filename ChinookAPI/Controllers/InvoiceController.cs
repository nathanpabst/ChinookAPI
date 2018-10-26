using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookAPI.DataAccess;
using ChinookAPI.Models;

namespace ChinookAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("api/controller")]
    public class InvoiceController : ControllerBase
    {
        InvoiceStorage _invoices = new InvoiceStorage();
        InvoiceStorage _agents = new InvoiceStorage();

        [HttpGet]
        public IActionResult GetInvoices()
        {
            return Ok(_invoices.GetInvoices());
        }

        [HttpGet]
        public IActionResult GetInvoicesByRep()
        {
            return Ok(_agents.GetInvoicesByRep());
        }
    }
}