using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookAPI.DataAccess;
using ChinookAPI.Models;
using Microsoft.Extensions.Configuration;

namespace ChinookAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Route("api/controller")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceStorage _invoices;
        private readonly InvoiceStorage _agents; 

        public InvoiceController(IConfiguration config)
        {
         _agents = new InvoiceStorage(config);
         _invoices = new InvoiceStorage(config);

        }

        // #1
        [HttpGet("invoices")]
        public IActionResult GetInvoices()
        {
            return Ok(_invoices.GetInvoices());
        }

        // #2
        [HttpGet("invoicesByRep")]
        public IActionResult GetInvoicesByRep()
        {
            return Ok(_agents.GetInvoicesByRep());
        }

        // #3
        [HttpGet("invoiceByLineItems/{id}")]
        public IActionResult GetLineItems(int id)
        {
            return Ok(_invoices.GetLineItems(id));
        }

        // #4
        [HttpPost("addInvoice")]
        public IActionResult PostInvoice(Invoice invoice)
        {
            var success = _invoices.AddInvoice(1, "1234 Main St.");
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { Message = "Invoice was not added." });
            }
        }

    }
}