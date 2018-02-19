using FraudScanner.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FraudScanner.Core.Interfaces
{
    public interface IRuleMain
    {
        Task<List<RuleDisplayView>> GetRules(RuleDisplayViewSearch ruleDisplayViewSearch);

        Task<List<RuleType>> GetRuleTypes();

        Task <int> AddRule(Rule newRule);

        Task<int> UpdateRule(Rule modifyRule);
    }
}
