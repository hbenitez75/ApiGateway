using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBillableTransaction.TransactionManager
{
    public enum TransactionStatus
    {
        UnBilled,
        Billed,
        Paid,
        Late,
        Void
    }
}
