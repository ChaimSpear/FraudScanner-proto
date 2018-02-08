using System;
using System.Collections.Generic;
using System.Text;

namespace FraudScanner.Core.Models
{
    public class Rule
    {
        public long Id { get; set; }

        public int RuleTypeId { get; set; }

        public string RuleDesc { get; set; }

        public int TimeSpanMinutes { get; set; }
        public double MeasurementAmount { get; set; } 
        public Nullable<int> FraudScore { get; set; }
         
        public Nullable<int> TransactionTypeId { get; set; }

        public Nullable<System.DateTime> ActiveDate { get; set; }
        public Nullable<System.DateTime> InactiveDate { get; set; } 
    }
}
