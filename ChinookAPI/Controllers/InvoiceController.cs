﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChinookAPI.DataAccess;
using ChinookAPI.Models;

namespace ChinookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        InvoiceStorage _invoices = new InvoiceStorage();

        [HttpGet]
        public IActionResult GetInvoices()
        {
            return Ok(_invoices.GetInvoices());
        }
    }
}