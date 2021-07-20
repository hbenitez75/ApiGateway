﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.Sqlite;

namespace ApiInvoices.Data
{
    public class DataBaseCreate :IDataBaseCreate
    {
        public readonly DataBaseName dataBaseName;
        public DataBaseCreate(DataBaseName _dataBaseName)
        {
            dataBaseName = _dataBaseName;
        }

        public void Setup()
        {
            var connection = new SqliteConnection(dataBaseName.Name);
            string query = @"SELECT name FROM sqlite_master WHERE type='table' AND name = 'Invoice';";
            var invoiceTable = connection.Query<string>(query);
            var invoiceTableName = invoiceTable.FirstOrDefault();
            if (!string.IsNullOrEmpty(invoiceTableName) && invoiceTableName == "Invoice")
                return;
            connection.ExecuteAsync("Create Table Invoice (" +
                "InvoiceNumber VARCHAR(100),"+
                "Description VARCHAR(100), " +
                "InvoiceDate DATE, " +
                "Amount      NUMERIC, " +
                "Paid        INTEGER, "+
                "PaidDate    DATE);");

            // The table below wont be necessary it we had use rabbitmq..
                        
                var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'BillTransaction';");
                var tableName = table.FirstOrDefault();
                if (!string.IsNullOrEmpty(tableName) && tableName == "BillTransaction")
                    return;
                
                connection.Execute("Create Table BillTransaction (" +
                    "CreateDate      DATE, " +
                    "TransactionDate DATE, " +
                    "BilledDate      DATE, " +
                    "PaidDate        DATE, " +
                    "Amount          NUMERIC, " +
                    "Status          NUMERIC, " +
                    "InvoiceNumber   VARCHAR(100);"); 
            
        }
    }
}