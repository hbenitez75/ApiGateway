using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using ApiInvoices.Data;
using Dapper;

namespace ApiInvoices.InvoiceManager
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataBaseName dataBaseName;
        public InvoiceRepository(DataBaseName _dataBaseName)
        {
            dataBaseName = _dataBaseName;
        }

        public async Task Create(Invoice invoice)
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            await connection.ExecuteAsync("INSERT INTO Invoice(InvoiceNumber,Description,InvoiceDate,Amount,Paid,PaidDate) "+
              "VALUES(@InvoiceNumber,@Description,@InvoiceDate,@Amount,@Paid,@PaidDate);",invoice);

        }

        public async Task Update(Invoice invoice)
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            await connection.ExecuteAsync("UPDATE Invoice SET Paid = @Paid, Amount = @Amount "+
                " WHERE InvoiceNumber = @InvoiceNumber;",invoice);

        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            return await connection.QueryAsync<Invoice>("SELECT rowid as Id,InvoiceNumber,Description,InvoiceDate,Amount," +
                "Paid,PaidDate FROM Invoice;");

        }
        public async Task<IEnumerable<Invoice>> GetInvoiceByNumber(string invoiceNumber)
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            return await connection.QueryAsync<Invoice>("SELECT rowid as Id,InvoiceNumber,InvoiceDate,Amount," +
                "Paid,PaidDate WHERE InvoiceNumber = @invoiceNumber;");

        }
        public async Task Update(string invoiceNumber)
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            await connection.ExecuteAsync("UPDATE Invoice SET Paid = @Paid " +
                "WHERE InvoiceNumber = @invoiceNumber;");

        }
    }
}
