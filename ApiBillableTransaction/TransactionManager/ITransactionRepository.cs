using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBillableTransaction.TransactionManager
{
    public interface ITransactionRepository
    {
        Task Create(Movements transaction);
        Task<IEnumerable<Movements>> GetAll();
        // In a CQRS patter the update commandl would be in a 
        // different repository 
        Task Update(Movements transaction);

    }
}
