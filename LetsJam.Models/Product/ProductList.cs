using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Product
{
    public class ProductList
    {
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

    }
}
