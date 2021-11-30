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
        [Display(Name ="Transaction ID")]
        public int TransactionId { get; set; }

        [Display(Name ="Product")]
        public string ProductName { get; set; }

        [Display(Name ="Quantity")]
        public int NumberOfProductPurchased { get; set; }

        [Display(Name ="Date of Transaction")]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfTransaction { get; set; }

    }
}
