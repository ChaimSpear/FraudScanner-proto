using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 

namespace FraudScanner.Web.ViewModels
{
    public class RuleViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Rule Type")]
        [Required]
        public int RuleTypeId { get; set; }

        [Display(Name = "Rule Description")]
        [Required]
        public string RuleDesc { get; set; }

        [Display(Name = "Time Span Minutes")]
        [Required]
        public int TimeSpanMinutes { get; set; }

        [Display(Name = "Measurement Amount")]
        [Required]
        public double MeasurementAmount { get; set; }

        [Display(Name = "Fraud Score")]
        public Nullable<int> FraudScore { get; set; }

        [Display(Name = "Transaction Type")]
        public Nullable<int> TransactionTypeId { get; set; }

        [Display(Name = "Active Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ActiveDate { get; set; }

        [Display(Name = "Inactive Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> InactiveDate { get; set; }

        public SelectList RuleTypes { get; set; }

        public SelectList TransactionTypes { get; set; }

    }
}
