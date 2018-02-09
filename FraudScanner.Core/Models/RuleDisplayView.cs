using System;
using System.Collections.Generic;
using System.Text;

namespace FraudScanner.Core.Models
{
    public class RuleDisplayView
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

       /* public string ActiveDateStr
        {
            get
            {
                var activeDateValStr = string.Empty;

                if (ActiveDate!= null)
                    activeDateValStr = ActiveDate.Value.ToString("G");

                return activeDateValStr;
            }
        }

        public string InactiveDateStr
        {
            get
            {
                var inActiveDateValStr = string.Empty;

                if (ActiveDate != null)
                    inActiveDateValStr = InactiveDate.Value.ToString("G");

                return inActiveDateValStr;
            }
        }*/

    }

    public class RuleDisplayViewSearch {
        public Nullable<int> RuleTypeId { get; set; }
        public Nullable<int> TransactionTypeId { get; set; }
    }
}
