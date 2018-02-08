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
            return View();
        }

        public ActionResult GetTransactions()
        {
            var transLst = _transactionMainService.GetTransactions();
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