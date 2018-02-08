using System;
using System.Collections.Generic;
using System.Text;

namespace FraudScanner.Core.Models
{
    public class TransactionActivityDisplayView
    {
        public long Id { get; set; }
        public int ClassId { get; set; }
        public DateTime TransDateTime { get; set; }
        public double TransAmount { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionTypeDesc { get; set; }

        public string TransDateTimeStr
        {
            get
            {
                return TransDateTime.ToString("G");
            }
        }
    }
}
