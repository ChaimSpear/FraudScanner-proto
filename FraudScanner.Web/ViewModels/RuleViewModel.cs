using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Web.ViewModels
{
    public class RuleViewModel
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
