using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;

namespace ApiBillableTransaction.TransactionManager
{
    public class TransactionRepository :ITransactionRepository
    {
        public DataBaseName dataBaseName;
        public TransactionRepository(DataBaseName _dataBaseName)
        {
            dataBaseName = _dataBaseName;
        }

        public async Task Create(Movements transaction)
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            await connection.ExecuteAsync("INSERT INTO Movements(Description,BillDate,Amount,Status,TransactionDate,InvoiceNumber) " +
             "VALUES(@Description, @BillDate, @Amount, @Status, @TransactionDate, @InvoiceNumber);", transaction);

            // FOR SOME REASON DE QUERY BELOW NEVER WORKED SO I CHANGED THE TABLE NAME 
            //await connection.ExecuteAsync("INSERT INTO BillTransaction(CreateDate,Description,TransactionDate, BilledDate,PaidDate,Amount,Status,InvoiceNumber) "+
            //"VALUES(@CreateDate,@Description,@TransactionDate, @BilledDate,@PaidDate,@Amount,@status,@InvoiceNumber);", transaction);



        }

        public async Task<IEnumerable<Movements>> GetAll()
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            return await connection.QueryAsync<Movements>("SELECT rowid as Id,Description,BillDate," +
                "Amount,Status,TransactionDate,InvoiceNumber FROM Movements;");
        }

        public async Task Update(Movements transaction)
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            var status = transaction.Status;
            var id = transaction.Id;
            var queryBill = @"UPDATE  Movements SET Status =@Status" +
                " WHERE rowid = @Id";
            //We set as billable the queryable records and the we recover those
            await connection.ExecuteAsync(queryBill,transaction);
        }

    }
}
