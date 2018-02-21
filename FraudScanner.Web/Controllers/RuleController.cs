using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using FraudScanner.Web.Service;
using FraudScanner.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            //TempData["Message"] = "test";
            ViewBag.RuleTypes = _ruleMainService.GetRuleTypes();
            ViewBag.TransactionTypes = _transactionMainService.GetTransactionTypes();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var newRule = new RuleViewModel();
            newRule.ActiveDate = new DateTime(2018, 1, 11);
            newRule.RuleTypes = new SelectList(
 
                _ruleMainService.GetRuleTypes(), "Id", "RuleTypeDesc");
            newRule.TransactionTypes = new SelectList(
                _transactionMainService.GetTransactionTypes(), "Id", "TransactionTypeDesc");

            return View("CreateEdit", newRule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RuleViewModel NewRule)
        {
            if (ModelState.IsValid)
            {
                _ruleMainService.AddRule(NewRule);

                TempData["Message"] = "Added New Rule";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RuleTypes = new SelectList(

                    _ruleMainService.GetRuleTypes(), "Id", "RuleTypeDesc");
                ViewBag.TransactionTypes = new SelectList(
                    _transactionMainService.GetTransactionTypes(), "Id", "TransactionTypeDesc");

            }
            return View("CreateEdit", NewRule);
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            var editRule = _ruleMainService.GetRule(Id);
            editRule.RuleTypes = new SelectList( 
                _ruleMainService.GetRuleTypes(), "Id", "RuleTypeDesc");
            editRule.TransactionTypes = new SelectList(
                _transactionMainService.GetTransactionTypes(), "Id", "TransactionTypeDesc");

            return View("CreateEdit", editRule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long Id, RuleViewModel EditRule)
        {
            if (ModelState.IsValid)
            {
                _ruleMainService.UpdateRule(EditRule   );

                TempData["Message"] = "Added New Rule";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RuleTypes = new SelectList(

                    _ruleMainService.GetRuleTypes(), "Id", "RuleTypeDesc");
                ViewBag.TransactionTypes = new SelectList(
                    _transactionMainService.GetTransactionTypes(), "Id", "TransactionTypeDesc");

            }
            return View("CreateEdit", EditRule);
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