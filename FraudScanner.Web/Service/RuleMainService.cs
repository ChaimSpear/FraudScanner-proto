using FraudScanner.Core.Interfaces;
using FraudScanner.Core.Models;
using FraudScanner.Web.ViewModels;
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

        public List<RuleDisplayViewModel> GetRules(Nullable<int> ruleTypeId, Nullable<int> transactionTypeId)
        {
            var ruleDisplayViewSearch = new RuleDisplayViewSearch { RuleTypeId= ruleTypeId,
                TransactionTypeId = transactionTypeId };
             
            return ConvertRuleDisplayViewsToRuleDisplayViewModels(
                _ruleMain.GetRules(ruleDisplayViewSearch).Result);
        }

        public List<RuleTypeViewModel> GetRuleTypes()
        {
            return ConvertRuleTypesToRuleTypeViewModels(_ruleMain.GetRuleTypes().Result);
        }

        public long AddRule(RuleViewModel NewRuleVm)
        {
            var newRule = new Rule
            {
                RuleTypeId = NewRuleVm.RuleTypeId,
                RuleDesc = NewRuleVm.RuleDesc,
                TimeSpanMinutes = NewRuleVm.TimeSpanMinutes,
                MeasurementAmount = NewRuleVm.MeasurementAmount,
                FraudScore = NewRuleVm.FraudScore,
                TransactionTypeId = NewRuleVm.TransactionTypeId,
                ActiveDate = NewRuleVm.ActiveDate,
                InactiveDate = NewRuleVm.InactiveDate
            };

            return _ruleMain.AddRule(newRule).Result;
        }
         
        public long UpdateRule(RuleViewModel UpdateRuleVm)
        {
            var rule = _ruleMain.GetRule(UpdateRuleVm.Id).Result;

            rule.RuleTypeId = UpdateRuleVm.RuleTypeId;
            rule.RuleDesc = UpdateRuleVm.RuleDesc;
                rule.TimeSpanMinutes = UpdateRuleVm.TimeSpanMinutes;
                rule.MeasurementAmount = UpdateRuleVm.MeasurementAmount;
            rule.FraudScore = UpdateRuleVm.FraudScore;
                rule.TransactionTypeId = UpdateRuleVm.TransactionTypeId;
                rule.ActiveDate = UpdateRuleVm.ActiveDate;
            rule.InactiveDate = UpdateRuleVm.InactiveDate;

            return _ruleMain.UpdateRule(rule).Result;
        }

        public RuleViewModel GetRule(long id)
        {
            var rule = _ruleMain.GetRule(id).Result;

            return ConvertRuleToRuleViewModel(rule);
        }

        public RuleViewModel ConvertRuleToRuleViewModel(Rule ruleToConvert)
        {
            return new RuleViewModel
            {
                Id = ruleToConvert.Id,
                RuleTypeId = ruleToConvert.RuleTypeId,
                RuleDesc = ruleToConvert.RuleDesc,
                TimeSpanMinutes = ruleToConvert.TimeSpanMinutes,
                MeasurementAmount = ruleToConvert.MeasurementAmount,
                FraudScore = ruleToConvert.FraudScore,
                TransactionTypeId = ruleToConvert.TransactionTypeId,
                ActiveDate = ruleToConvert.ActiveDate,
                InactiveDate = ruleToConvert.InactiveDate
            };
        }

        private List<RuleTypeViewModel> ConvertRuleTypesToRuleTypeViewModels(List<RuleType> RuleTypes)
        {
            var RuleTypeViewModels = new List<RuleTypeViewModel>();
            for (int i = 0; i < RuleTypes.Count; i++)
            {
                RuleTypeViewModels.Add(
                    new RuleTypeViewModel
                    {
                        Id = RuleTypes[i].Id,
                        MeasurementAmountDesc = RuleTypes[i].MeasurementAmountDesc,
                        RuleTypeDesc = RuleTypes[i].RuleTypeDesc
                    }
                    );
            }

            return RuleTypeViewModels;
        }

        private List<RuleDisplayViewModel> ConvertRuleDisplayViewsToRuleDisplayViewModels(List<RuleDisplayView> RuleDisplayViews)
        {
            var RuleDisplayViewModels = new List<RuleDisplayViewModel>();
            for (int i = 0; i < RuleDisplayViews.Count; i++)
            {
                RuleDisplayViewModels.Add(
                    new RuleDisplayViewModel
                    {
                        Id = RuleDisplayViews[i].Id,
                        RuleTypeId = RuleDisplayViews[i].RuleTypeId,
                        RuleDesc = RuleDisplayViews[i].RuleDesc,
                        TimeSpanMinutes = RuleDisplayViews[i].TimeSpanMinutes,
                        MeasurementAmount = RuleDisplayViews[i].MeasurementAmount,
                        FraudScore = RuleDisplayViews[i].FraudScore,
                        TransactionTypeId = RuleDisplayViews[i].TransactionTypeId, 
                        RuleTypeDesc = RuleDisplayViews[i].RuleTypeDesc,
                        TransactionTypeDesc = RuleDisplayViews[i].TransactionTypeDesc,
                        ActiveDate = RuleDisplayViews[i].ActiveDate,
                        InactiveDate = RuleDisplayViews[i].InactiveDate 
                    }
                    );
            }

            return RuleDisplayViewModels;
        } 
    }
}
