using FraudScanner.Core.Interfaces;
using FraudScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Web.Service
{  
    public class RuleMainService
    {
        private readonly IRuleMain _ruleMain;

        public RuleMainService(IRuleMain ruleMain)
        {
            _ruleMain = ruleMain;
        }

        public List<RuleDisplayView> GetRules(Nullable<int> ruleTypeId, Nullable<int> transactionTypeId)
        {
            var ruleDisplayViewSearch = new RuleDisplayViewSearch { RuleTypeId= ruleTypeId,
                TransactionTypeId = transactionTypeId };
            return _ruleMain.GetRules(ruleDisplayViewSearch).Result;
        }

        public List<RuleType> GetRuleTypes()
        {
            return _ruleMain.GetRuleTypes().Result;
        }
    }
}
