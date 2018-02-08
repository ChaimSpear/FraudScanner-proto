using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 
using System.Web.Script.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FraudScanner.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return Content("test abc") ;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult TestJson()
        {
            var TestTransLst = new List<TestTrans>();

            TestTransLst.Add(new TestTrans { TransId=444,TransAmount=4.55, TransType="BUY", TransDate= new DateTime(2018, 1, 12, 12, 1, 22) });
            TestTransLst.Add(new TestTrans { TransId = 122, TransAmount = 127.00, TransType = "BUY", TransDate = new DateTime(2018, 1, 16, 11, 1, 11) });
            TestTransLst.Add(new TestTrans { TransId = 733, TransAmount = 6.44, TransType = "SELL", TransDate= new DateTime(2018, 1, 22, 12, 1, 11) });
            TestTransLst.Add(new TestTrans { TransId = 164, TransAmount = 66.55, TransType = "RETURN", TransDate = new DateTime(2018, 1, 12, 11 ,1, 11) });

            var result = new
            {
                total = 1,
                page = 1,
                records = TestTransLst.Count,
                rows = TestTransLst
            };

          //  return Json( JsonConvert.SerializeObject(result));
            return Json(result);
            //return serializerJsonResult(TestTransLst);
        }

        public ActionResult serializerJsonResult(object result)
        {

            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;

            var resultJson = new ContentResult
            {
                Content = serializer.Serialize(result),
                ContentType = "application/json"
            };

            return resultJson;
        }
    }

    public class TestTrans {
        public int TransId { get; set; }

        // [DataType(DataType.DateTime)]
        //[JsonProperty]
       // [JsonConverter(typeof(JavaScriptDateTimeConverter))]
        public System.DateTime TransDate { get; set; }

        public string TransDateStr
            {
            get
            { return TransDate.ToString("G"); }
}

        public double TransAmount { get; set; }
        public string TransType { get; set; }
    }
}