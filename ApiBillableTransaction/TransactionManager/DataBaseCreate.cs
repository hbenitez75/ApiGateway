using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Dapper;


namespace ApiBillableTransaction.TransactionManager
{
    public class DataBaseCreate : IDataBaseCreate
    {
        public DataBaseName dataBaseName;
        public DataBaseCreate(DataBaseName _dataBaseName)
        {
            dataBaseName = _dataBaseName;
        }
        public void Setup()
        {
            using var connection = new SqliteConnection(dataBaseName.Name);
            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Movements';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Movements")
                return;
           
            connection.Execute("Create Table Movements (" +
                "Description     VARCHAR(100), " +
                "BillDate        DATE, " +                
                "Amount          NUMERIC, " +
                "Status          INT, "+
                "TransactionDate DATE, "+
                "InvoiceNumber   VARCHAR(100));");

        }
    }
}
