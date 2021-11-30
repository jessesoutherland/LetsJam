using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Product
{
    public class ProductCreate
    {
        [Required]
        [Display(Name = "SKU:")]
        public string SKU { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price:")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Inventory:")]
        public int NumberInStock { get; set; }
    }
}
