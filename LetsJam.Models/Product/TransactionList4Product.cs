using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Product
{
    public class TransactionList4Product
    {
        public int TransactionId { get; set; }
        public string MemberName { get; set; }
        public int NumberOfProductPurchased { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset DateOfTransaction { get; set; }
    }
}
