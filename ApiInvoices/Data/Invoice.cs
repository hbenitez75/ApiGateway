using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiInvoices.Data
{
    public class Invoice
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public DateTime InvoiceDate { set; get; } // the date the transaction was marked as billed.
        public DateTime PaidDate { set; get; }
        public Double Amount { set; get; }
        public string InvoiceNumber { set; get; }
        public int Paid { set; get; } // 

    }
}
