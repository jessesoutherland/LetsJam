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
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }

        [Display(Name ="Jammer")]
        public string MemberName { get; set; }

        [Display(Name = "Quantity")]
        public int NumberOfProductPurchased { get; set; }

        [Display(Name = "Date of Transaction")]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfTransaction { get; set; }
    }
}
