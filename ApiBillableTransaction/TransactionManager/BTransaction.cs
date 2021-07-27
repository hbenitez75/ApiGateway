using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBillableTransaction.TransactionManager;

namespace ApiBillableTransaction.TransactionManager
{
    public class BTransaction
    {
        public int Id { set; get; }
        public DateTime CreateDate { set; get; }
        public string Description { set; get; }
        public DateTime TransactionDate { set; get; }
        public DateTime BilledDate { set; get; }
        public DateTime PaidDate { set; get; }
        public double Amount { set; get; }       
        public int Status { set; get; }
        public string InvoiceNumber { set; get; }
    }
}
