using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Data
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public string SKU { get; set; }

        [Required]
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfTransaction { get; set; }

        [Required]
        public int NumberOfProductPurchased { get; set; }

        public virtual Product Product { get; set; }
        public virtual Member Member { get; set; }
    }
}
