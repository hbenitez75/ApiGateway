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

        public async Task Create(Transaction transaction)
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            await connection.ExecuteAsync("INSERT INTO BillTransaction(CreateDate,Description,TransactionDate, BilledDate,PaidDate,Amount,Status,InvoiceNumber) VALUES(@CreateDate,@Description,@TransactionDate, @BilledDate,@PaidDate,@Amount,@status,@InvoiceNumber);", transaction);
            //                "VALUES(@CreateDate,@Description,@TransactionDate, @BilledDate,@PaidDate,@Amount,@status,@InvoiceNumber);", transaction);


        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            return await connection.QueryAsync<Transaction>("SELECT rowid as Id,CreateDate,TransactionDate," +
                "Description,Amount,Status FROM BillTransaction;");
        }

        public async Task Update(Transaction transaction)
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            var id = transaction.Id;
            var queryBill = @"UPDATE  BillTransaction SET status =@status" +
                " WHERE rowId = @id";
            //We set as billable the queryable records and the we recover those
            await connection.ExecuteAsync(queryBill);
        }

    }
}
