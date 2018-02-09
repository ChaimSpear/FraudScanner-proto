using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FraudScanner.Web.Service;
using Microsoft.AspNetCore.Mvc;

namespace FraudScanner.Web.Controllers
{
    public class TransactionActivityController : Controller
    {
        private readonly TransactionMainService _transactionMainService;

        public TransactionActivityController(TransactionMainService transactionMainService)
        { _transactionMainService = transactionMainService; }

        public IActionResult Index()
        {
            ViewBag.DefaultFromDateStr = DateTime.Now.AddMonths(-1).ToString("MM/dd/yyyy");
            ViewBag.DefaultToDateStr = DateTime.Now.ToString("MM/dd/yyyy");
            ViewBag.TransactionTypes = _transactionMainService.GetTransactionTypes();

            return View();
        }

        public ActionResult GetTransactions(Nullable<int> TransactionTypeId,
            Nullable<int> AccountId,
            DateTime FromDate,
            DateTime ToDate)
        {
            var transLst = _transactionMainService.GetTransactions(TransactionTypeId,
                AccountId, FromDate, ToDate);
            var result = new
            {
                total = 1,
                page = 1,
                records = transLst.Count,
                rows = transLst
            };
             
            return Json(result); 
        }

    }
}