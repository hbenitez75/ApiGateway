using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiInvoices.Data;

namespace ApiInvoices.InvoiceManager
{
    public interface IInvoiceRepository
    {
        Task Create(Invoice invoice );
        Task Update(Invoice invoice);
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<IEnumerable<Invoice>> GetInvoiceByNumber(string invoiceNumber);
        // This one might not be repository Pattern ..  
        Task Update(string invoiceNumber);

    }
}
