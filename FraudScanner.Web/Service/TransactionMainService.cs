﻿using FraudScanner.Core.Interfaces;
using FraudScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Web.Service
{
    public class TransactionMainService
    {
        private readonly ITransactionMain _transactionMain;

        public TransactionMainService(ITransactionMain transactionMain)
        {
            _transactionMain = transactionMain;
        }

        public List<TransactionActivityDisplayView> GetTransactions(Nullable<int> transactionTypeId,
            Nullable<int> accountId,
            DateTime fromDate,
            DateTime toDate)
        {

            var viewSearch = new TransactionActivityDisplayViewSearch
            {
                TransactionTypeId = transactionTypeId,
                AccountId = accountId,
                FromTransDate = fromDate,
                ToTransDate = toDate
            };

            return _transactionMain.GetTransactionActivity(viewSearch).Result;
        }

        public List<TransactionType> GetTransactionTypes()
        {
            return _transactionMain.GetTransactionTypes().Result;
        }
    }
}
