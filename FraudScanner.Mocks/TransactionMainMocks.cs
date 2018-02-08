using FraudScanner.Core.Interfaces;
using FraudScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FraudScanner.Mocks
{
    public class TransactionMainMocks : ITransactionMain
    { 
        public Task<List<TransactionActivityDisplayView>> GetTransactionActivity()
        { 
            return Task.FromResult(GenerateDisplayView());
        }

        public Task<List<TransactionType>> GetTransactionTypes()
        {
            var transactionTypeMockList = new List<TransactionType>();

            transactionTypeMockList.Add(new TransactionType { Id = 1, TransactionTypeDesc = "Buy" });
            transactionTypeMockList.Add(new TransactionType { Id = 2, TransactionTypeDesc = "Sell" });
            transactionTypeMockList.Add(new TransactionType { Id = 3, TransactionTypeDesc = "Refund" });

            return Task.FromResult(transactionTypeMockList);
        }

        private List<TransactionActivityDisplayView> GenerateDisplayView()
        {
            var transactionActivityDisplayViewList = new List<TransactionActivityDisplayView>();
            var transactionTypeMockList = GetTransactionTypes().Result;

            var transactionActivityMockList = GetTransactionActivityMockList();

            for (int i = 0; i < transactionActivityMockList.Count; i++) {
                var transactionActivity = transactionActivityMockList[i];

                var transactionActivityDisplayView = GetDisplayViewFromRec(transactionActivity, transactionTypeMockList);

                transactionActivityDisplayViewList.Add(transactionActivityDisplayView);
            }

            return transactionActivityDisplayViewList;
        }

        private TransactionActivityDisplayView GetDisplayViewFromRec(TransactionActivity transactionActivity, List<TransactionType> transactionTypeMockList)
        {
            var displayView = new TransactionActivityDisplayView {
                AccountId = transactionActivity.AccountId,
                ClassId = transactionActivity.ClassId,
                TransactionTypeId = transactionActivity.TransactionTypeId,
                TransAmount = transactionActivity.TransAmount,
                TransDateTime = transactionActivity.TransDateTime,
                Id = transactionActivity.Id  
            };

            var transType = transactionTypeMockList.Find(a => a.Id == displayView.TransactionTypeId);

            if (transType != null)
                displayView.TransactionTypeDesc = transType.TransactionTypeDesc;

            return displayView;
        }

        private List<TransactionActivity> GetTransactionActivityMockList()
            {
            var transactionActivityMockList = new List<TransactionActivity>();

            transactionActivityMockList.Add(
                new TransactionActivity
                {
                    Id = 100,
                    AccountId = 500,
                    ClassId = 600,
                    TransactionTypeId = 1,
                    TransAmount = 500,
                    TransDateTime = new DateTime(2018, 1, 12, 12, 1, 11)
                });

            transactionActivityMockList.Add(
                new TransactionActivity
                {
                    Id = 103,
                    AccountId = 500,
                    ClassId = 600,
                    TransactionTypeId = 2,
                    TransAmount = 100,
                    TransDateTime = new DateTime(2018, 1, 12, 12, 33, 11)
                }); 

            transactionActivityMockList.Add(
               new TransactionActivity
               {
                   Id = 222,
                   AccountId = 600,
                   ClassId = 600,
                   TransactionTypeId = 3,
                   TransAmount = 12.50,
                   TransDateTime = new DateTime(2018, 1, 12, 14, 33, 11)
               });

            transactionActivityMockList.Add(
               new TransactionActivity
               {
                   Id = 103,
                   AccountId = 830,
                   ClassId = 700,
                   TransactionTypeId = 1,
                   TransAmount = 50,
                   TransDateTime = new DateTime(2018, 1, 12, 17, 33, 11)
               });

            return  transactionActivityMockList ;
        }

         
    }
}
