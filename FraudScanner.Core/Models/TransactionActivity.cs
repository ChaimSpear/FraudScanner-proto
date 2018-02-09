using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudScanner.Core.Models
{
    public class TransactionActivity
    {
        public long Id { get; set; }
        public int ClassId { get; set; }
        public DateTime TransDateTime { get; set; }
        public double TransAmount { get; set; }
        public int AccountId { get; set; }
        public int TransactionTypeId { get; set; }
         
    }
     
}
