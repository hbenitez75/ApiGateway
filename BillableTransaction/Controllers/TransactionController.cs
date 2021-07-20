using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBillableTransaction.TransactionManager;

namespace ApiBillableTransaction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {        
        public readonly ITransactionRepository transactionRepository;
        public TransactionController(ITransactionRepository _transactionRepository)
        {
            transactionRepository = _transactionRepository;

        }

        [HttpPost]
        public async Task Post([FromBody] Transaction transaction)
        {
            await transactionRepository.Create(transaction);
        }

        [HttpGet]
        public async Task<IEnumerable<Transaction>> Get()
        {
            return await transactionRepository.GetAll();
        }

        [HttpPut]
        public async Task Put([FromBody] Transaction transaction)
        {
            await transactionRepository.Update(transaction);
        }


    }
}
