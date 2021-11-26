using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Transaction
{
    public class TransactionList4Member
    {
        public int TransactionId { get; set; }
        public string ProductName { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateOfTransaction { get; set; }
        public int NumberOfProductPurchased { get; set; }
    }
}
