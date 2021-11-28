using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Transaction
{
    public class TransactionList
    {
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Jammer")]
        public string MemberName { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTimeOffset DateOfTransaction { get; set; }

    }
}
