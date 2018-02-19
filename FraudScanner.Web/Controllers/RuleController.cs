using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using FraudScanner.Web.Service;
using FraudScanner.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FraudScanner.Web.Controllers
{
    public class RuleController : Controller
    {
        private readonly RuleMainService _ruleMainService;
        private readonly TransactionMainService _transactionMainService;

        public RuleController(RuleMainService ruleMainService,
            TransactionMainService transactionMainService)
        {
            _ruleMainService = ruleMainService;
            _transactionMainService = transactionMainService;
        }

        public IActionResult Index()
        {
            ViewBag.RuleTypes = _ruleMainService.GetRuleTypes();
            ViewBag.TransactionTypes = _transactionMainService.GetTransactionTypes();
            return View();
        }

        [HttpGet]
        public IActionResult Add(RuleViewModel newRule)
        {
            ViewBag.RuleTypes = _ruleMainService.GetRuleTypes();
            ViewBag.TransactionTypes = _transactionMainService.GetTransactionTypes();
            return View(newRule);
        }

        public ActionResult GetRules(Nullable<int> RuleTypeId, Nullable<int> TransactionTypeId)
        {
            var ruleLst = _ruleMainService.GetRules(RuleTypeId, TransactionTypeId);
            var result = new
            {
                total = 1,
                page = 1,
                records = ruleLst.Count,
                rows = ruleLst
            };

            return Json(result);
        }
    }
}