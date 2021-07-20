using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;
using ApiBillableTransaction.TransactionManager;

namespace ApiBillableTransaction.TransactionManager
{
    public class BillTransactions
    {
        public DataBaseName dataBaseName;
        public void BillableTransaction(DataBaseName _dataBaseName)
        {
            dataBaseName = _dataBaseName;
        }

        public async Task Tobill(DateTime from, DateTime to)
        {
            Guid guid = Guid.NewGuid();
            var connection = new SqliteConnection(dataBaseName.Name);
            var status = TransactionStatus.Billed;
            var queryBill = @"UPDATE  BillTransaction SET status =@status,InvoiceNumber = @guid" +
                " WHERE TransactionDate BETWEEN @_from AND @_to;";
            //We set as billable the queryable records and the we recover those
            await connection.ExecuteAsync(queryBill);
           
        }

    }
}
