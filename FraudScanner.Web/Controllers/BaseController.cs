using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FraudScanner.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            ViewBag.GetDisplayMessage = new Func<string>(GetDisplayMessage);
        }

        public string GetDisplayMessage()
        {
            string MsgToDisplay = string.Empty;

            if (TempData["Message"] != null)
                MsgToDisplay += TempData["Message"] + " ";

            if (ViewBag.Message != null)
                MsgToDisplay += ViewBag.Message + " ";

            return MsgToDisplay; 
        }
    }
}