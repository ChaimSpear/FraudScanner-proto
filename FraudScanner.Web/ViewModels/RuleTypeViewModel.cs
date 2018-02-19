using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Web.ViewModels
{
    public class RuleTypeViewModel
    {
        public long Id { get; set; }

        public string RuleTypeDesc { get; set; }

        public string MeasurementAmountDesc { get; set; }
    }
}
