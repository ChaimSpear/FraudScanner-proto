using System;
using System.Collections.Generic;
using System.Text;

namespace FraudScanner.Core.Models
{
    public class RuleType
    {
        public long Id { get; set; }
        
        public string RuleTypeDesc { get; set; }

        public string MeasurementAmountDesc { get; set; }
    }
}
