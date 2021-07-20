using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBillableTransaction.TransactionManager
{
    public interface ITransactionRepository
    {
        Task Create(Transaction transaction);
        Task<IEnumerable<Transaction>> GetAll();
        // In a CQRS patter the update commandl would be in a 
        // different repository 
        Task Update(Transaction transaction);

    }
}
