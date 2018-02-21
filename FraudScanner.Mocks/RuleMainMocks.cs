using FraudScanner.Core.Interfaces;
using FraudScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FraudScanner.Mocks
{
    public class RuleMainMocks : IRuleMain
    {
        private readonly ITransactionMain _transactionMain;

        private List<RuleType> RuleTypeMockList;
        private List<Rule> RuleMockList; 

        public RuleMainMocks(ITransactionMain transactionMain)
        {
            _transactionMain = transactionMain;

            GenerateRuleTypes();

            GenerateRules();
        }

        public Task<List<RuleDisplayView>> GetRules(RuleDisplayViewSearch ruleDisplayViewSearch)
        {
            return Task.FromResult(GenerateDisplayView(ruleDisplayViewSearch));
        }

        public Task<List<RuleType>> GetRuleTypes()
        {
           // var ruleTypeMockList = new List<RuleType>();

           // ruleTypeMockList.Add(new RuleType { Id = 1, RuleTypeDesc = "Total Trans Amount", MeasurementAmountDesc= "Trans Amount" });
           // ruleTypeMockList.Add(new RuleType { Id = 2, RuleTypeDesc = "Number of Transactions", MeasurementAmountDesc = "# Transactions" });

            return Task.FromResult(RuleTypeMockList);
        }

        public Task<long> AddRule(Rule newRule)
        {
            var maxId = RuleMockList.Max(a => a.Id);
            newRule.Id = maxId + 1;

            RuleMockList.Add(newRule);
            return Task.FromResult(newRule.Id);
        }

        public Task<long> UpdateRule(Rule modifyRule)
        {
            long a = 4;
            return Task.FromResult ( a);
        }

        private void GenerateRuleTypes()
        {
            RuleTypeMockList = new List<RuleType>();

            RuleTypeMockList.Add(new RuleType { Id = 1, RuleTypeDesc = "Total Trans Amount", MeasurementAmountDesc = "Trans Amount" });
            RuleTypeMockList.Add(new RuleType { Id = 2, RuleTypeDesc = "Number of Transactions", MeasurementAmountDesc = "# Transactions" });

        }

        private void GenerateRules()
        {
            RuleMockList = new List<Rule>();

            RuleMockList.Add(
                new Rule
                {
                    Id = 100,
                    RuleTypeId = 1,
                    RuleDesc = "Rule #1 - Tot Trans Amt",
                    TimeSpanMinutes = 60,
                    MeasurementAmount = 17.50,
                    TransactionTypeId = 1,
                    FraudScore = 3,
                    ActiveDate = new DateTime(2017, 1, 1),
                    InactiveDate = new DateTime(2019, 1, 1)
                });

            RuleMockList.Add(
                new Rule
                {
                    Id = 103,
                    RuleTypeId = 2,
                    RuleDesc = "Rule #2 - Num Trans Made",
                    TimeSpanMinutes = 40,
                    MeasurementAmount = 6,
                    FraudScore = 1,
                    ActiveDate = new DateTime(2017, 5, 1),
                });

            RuleMockList.Add(
               new Rule
               {
                   Id = 120,
                   RuleTypeId = 2,
                   RuleDesc = "Rule #3 - Num Trans Made ABC",
                   TimeSpanMinutes = 90,
                   MeasurementAmount = 10,
                   FraudScore = 2,
                   ActiveDate = new DateTime(2017, 5, 1),
               });
        }

        private List<RuleDisplayView> GenerateDisplayView(RuleDisplayViewSearch ruleDisplayViewSearch)
        {
            var ruleDisplayViewList = new List<RuleDisplayView>();
            var transactionTypeMockList = _transactionMain.GetTransactionTypes().Result;
            //var ruleTypeMockList = GetRuleTypes().Result;

            var ruleMockList = GetRuleMockList();

            for (int i = 0; i < ruleMockList.Count; i++)
            {
                var rule = ruleMockList[i];

                if ( (!ruleDisplayViewSearch.RuleTypeId.HasValue ||
                    ruleDisplayViewSearch.RuleTypeId.Value == rule.RuleTypeId)
                    && (!ruleDisplayViewSearch.TransactionTypeId.HasValue ||
                    (rule.TransactionTypeId.HasValue 
                    && ruleDisplayViewSearch.TransactionTypeId.Value == rule.TransactionTypeId.Value) ))
                {   
                    var ruleDisplayView = GetDisplayViewFromRec(rule, RuleTypeMockList, transactionTypeMockList);

                    ruleDisplayViewList.Add(ruleDisplayView);
                }
            }

            return ruleDisplayViewList;
        }

        private RuleDisplayView GetDisplayViewFromRec(Rule rule,
            List<RuleType> ruleTypeMockList,
            List<TransactionType> transactionTypeMockList)
        {
            var displayView = new RuleDisplayView
            { 
                Id = rule.Id,
                RuleTypeId = rule.RuleTypeId,
                RuleDesc = rule.RuleDesc,
                TimeSpanMinutes = rule.TimeSpanMinutes,
                MeasurementAmount = rule.MeasurementAmount,
                FraudScore = rule.FraudScore,
                ActiveDate = rule.ActiveDate,
                InactiveDate = rule.InactiveDate,
                TransactionTypeId = rule.TransactionTypeId 
            };

            var transType = transactionTypeMockList.Find(a => a.Id == displayView.TransactionTypeId);
            var ruleType = ruleTypeMockList.Find(a => a.Id == displayView.RuleTypeId);

            if (transType != null)
                displayView.TransactionTypeDesc = transType.TransactionTypeDesc;

            if (ruleType != null)
                displayView.RuleTypeDesc = ruleType.RuleTypeDesc;

            return displayView;
        }

        private List<Rule> GetRuleMockList()
        { 
            return RuleMockList;
        }
    }
}
