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
    public class GenerateInvoices
    {
        public readonly DataBaseName dataBaseName;
        public readonly InvoiceRepository invoiceRepository;
        public GenerateInvoices(DataBaseName _databaseName,InvoiceRepository _invoiceRepository)
        {
            dataBaseName = _databaseName;
            invoiceRepository = _invoiceRepository;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByDate(DateTime from, DateTime to )
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            var status = TransactionStatus.Billed;
            string guid = Guid.NewGuid().ToString("D");
            var queryBill = @"UPDATE  Movements SET status =@status, " +
                "InvoiceNumber = @guid "+
                " WHERE BillDate BETWEEN @_from AND @_to;";
            await connection.ExecuteAsync(queryBill);
            var invoices = connection.QueryAsync<Invoice>("SELECT 1,'My Invoice',DATE('now'),Date(now,'-1 MONTHS'),SUM(Amount),0 FROM Movements GROUP BY InvoiceNumber ;");

            Invoice invoice= invoices.Result.SingleOrDefault(x => x.InvoiceNumber == guid);

            await invoiceRepository.Create(invoice);
            var list = new List<Invoice>();
            list.Add(invoice);
            return list.AsEnumerable();

        }
    }
}
