using FraudScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FraudScanner.Core.Interfaces
{ 
    public interface ITransactionMain
    {
        Task<List<TransactionActivityDisplayView>> GetTransactionActivity(TransactionActivityDisplayViewSearch searchCrit);

        Task<List<TransactionType>> GetTransactionTypes();
    }
}
