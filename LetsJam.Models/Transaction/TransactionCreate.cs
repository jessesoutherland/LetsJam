using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Transaction
{
    public class TransactionCreate
    {
        public string SKU { get; set; }
        public int MemberId { get; set; }
        public int NumberOfProductPurchased { get; set; }
    }
}
