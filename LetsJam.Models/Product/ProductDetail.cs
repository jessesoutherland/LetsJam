using LetsJam.Data;
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
        public string SKU { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Inventory")]
        public int NumberInStock { get; set; }
        public virtual ICollection<TransactionList4Product> Transactions { get; set; } = new List<TransactionList4Product>();

    }
}
