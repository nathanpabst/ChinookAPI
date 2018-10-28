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
        private readonly InvoiceStorage _insertInvoice;
        private readonly InvoiceStorage _updateEmpName;

        public InvoiceController(IConfiguration config)
        {
            _agents = new InvoiceStorage(config);
            _invoices = new InvoiceStorage(config);
            _insertInvoice = new InvoiceStorage(config);
            _updateEmpName = new InvoiceStorage(config);

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
        public IActionResult PostInvoice(NewInvoice newInvoice)
        {
            var success = _insertInvoice.PostInvoice(1, "1234 Main St.");
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { Message = "Invoice was not added." });
            }
        }

        // #5
        [HttpPut("updateName")]
        public IActionResult UpdateAgentName(EmployeeNameChange newName)
        {
            var success = _updateEmpName.UpdateEmployeeName(1, "bob", "loblaw");
            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { Message = "Name change was unsuccessful." });
            }
        }

    }
}