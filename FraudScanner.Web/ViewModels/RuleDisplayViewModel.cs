using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Web.ViewModels
{
    public class RuleDisplayViewModel
    {
        public long Id { get; set; }

        public int RuleTypeId { get; set; }

        public string RuleDesc { get; set; }

        public int TimeSpanMinutes { get; set; }

        public double MeasurementAmount { get; set; }

        public Nullable<int> FraudScore { get; set; }

        public Nullable<int> TransactionTypeId { get; set; }

        public string RuleTypeDesc { get; set; }

        public string TransactionTypeDesc { get; set; }

        public Nullable<DateTime> ActiveDate { get; set; }
        public Nullable<DateTime> InactiveDate { get; set; }
    }
}
