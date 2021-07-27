using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBillableTransaction.TransactionManager
{
    public class Movements
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public DateTime BillDate { set; get; }
        public Double Amount { set; get; }
        public int Status { set; get; }
        public DateTime TransactionDate { set; get; }
        public string InvoiceNumber { set; get; }

    }
}
