﻿using LetsJam.Data;
using LetsJam.Models.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Product
{
    public class ProductDetail
    {
        [Display(Name = "SKU:")]
        public string SKU { get; set; }

        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Display(Name = "Price:")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Inventory:")]
        public int NumberInStock { get; set; }
        public virtual ICollection<TransactionList4Product> Transactions { get; set; } = new List<TransactionList4Product>();

    }
}
