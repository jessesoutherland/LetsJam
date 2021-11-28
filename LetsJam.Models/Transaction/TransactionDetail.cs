﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Transaction
{
    public class TransactionDetail
    {
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }
        public string SKU { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Jammer ID")]
        public int MemberId { get; set; }

        [Display(Name = "Jammer")]
        public string MemberName { get; set; }

        [Display(Name = "Date of Sale")]
        public DateTimeOffset DateOfTransaction { get; set; }

        [Display(Name = "Quantity")]
        public int NumberOfProductPurchased { get; set; }
    }
}
