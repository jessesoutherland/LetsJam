﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Transaction
{
    public class TransactionDetail
    {
        public int TransactionId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public DateTimeOffset DateOfTransaction { get; set; }
        public int NumberOfProductPurchased { get; set; }
    }
}