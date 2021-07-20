using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiInvoices.Data;
using ApiInvoices.InvoiceManager;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiInvoices.Services
{
    public class PayInvoices
    {
        public readonly DataBaseName dataBaseName;
        public readonly InvoiceRepository invoiceRepository;
        public PayInvoices(DataBaseName _dataBaseName,InvoiceRepository _invoiceRepository)
        {
            dataBaseName = _dataBaseName;
            invoiceRepository = _invoiceRepository;
        }

        public async Task PayInvoice(string invoiceNumber)
        {
            await invoiceRepository.Update(invoiceNumber);
        }
    }
}
