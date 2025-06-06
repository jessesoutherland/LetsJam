﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Transaction
{
    public class TransactionEdit
    {
        public int TransactionId { get; set; }

        [Display(Name = "Product:")]
        public string SKU { get; set; }

        [Display(Name = "Jammer:")]
        public int MemberId { get; set; }

        [Display(Name = "Quantity:")]
        public int NumberOfProductPurchased { get; set; }
    }
}
