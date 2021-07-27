using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiInvoices.Data;
using ApiInvoices.InvoiceManager;


namespace ApiInvoices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicingController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;
        public InvoicingController(IInvoiceRepository _invoiceRepository)
        {
            invoiceRepository = _invoiceRepository;
        }
        
        [HttpPut]     
        public async Task Put([FromBody]  Invoice invoice)
        {
            await invoiceRepository.Update(invoice);
        }
        /*
        [HttpPut]
        public async Task Put([FromBody] string invoiceNumber )
        {
            await invoiceRepository.Update(invoiceNumber);
        }
        */
        [HttpPost]
        public async Task Post([FromBody] Invoice invoice)
        {
            await invoiceRepository.Create(invoice);
        }

        [HttpGet]
        public  async Task<IEnumerable<Invoice>> Get()
        {
             return await invoiceRepository.GetInvoices();
            
        }
    }
}
