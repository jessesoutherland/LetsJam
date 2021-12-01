using LetsJam.Data;
using LetsJam.Models.Product;
using LetsJam.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LetsJam.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateTransaction(TransactionCreate trans)
        {
            var model = new Transaction()
            {
                OwnerId = _userId,
                SKU = trans.SKU,
                MemberId = trans.MemberId,
                DateOfTransaction = DateTimeOffset.Now,
                NumberOfProductPurchased = trans.NumberOfProductPurchased
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(model);

                Product product = ctx.Products.Find(trans.SKU);
                product.NumberInStock -= trans.NumberOfProductPurchased;

                return ctx.SaveChanges() >= 1;
            }
        }
        public int CheckStock(TransactionCreate prod)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Single(p => p.OwnerId == _userId && p.SKU == prod.SKU);

                if (query.NumberInStock == 0)
                    return 0;

                return query.NumberInStock;
            }
        }

        //public bool UpdateStock(TransactionCreate prod)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.Products.Single(p => p.OwnerId == _userId && p.SKU == prod.SKU);

        //        query.NumberInStock -= prod.NumberOfProductPurchased;

        //        return ctx.SaveChanges() == 1;
        //    }
        //}
        public IEnumerable<TransactionList> GetAllTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions.Where(t => t.OwnerId == _userId).Select(t => new TransactionList
                {
                    TransactionId = t.TransactionId,
                    ProductName = t.Product.Name,
                    MemberName = t.Member.FirstName + " " + t.Member.LastName,
                    DateOfTransaction = t.DateOfTransaction
                });

                return query.ToArray();
            }
        }
        public TransactionDetail GetTransactionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions.Single(t => t.OwnerId == _userId && t.TransactionId == id);

                return new TransactionDetail
                {
                    TransactionId = query.TransactionId,
                    MemberId = query.MemberId,
                    MemberName = query.Member.FirstName + " " + query.Member.LastName,
                    SKU = query.SKU,
                    ProductName = query.Product.Name,
                    NumberOfProductPurchased = query.NumberOfProductPurchased,
                    DateOfTransaction = query.DateOfTransaction
                };
            }
        }

        public bool UpdateTransaction(TransactionEdit trans)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions.Single(t => t.OwnerId == _userId && t.TransactionId == trans.TransactionId);

                query.SKU = trans.SKU;
                query.MemberId = trans.MemberId;
                query.NumberOfProductPurchased = trans.NumberOfProductPurchased;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTransaction(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions.Single(t => t.OwnerId == _userId && t.TransactionId == id);

                ctx.Transactions.Remove(query);

                return ctx.SaveChanges() == 1;
            }
        }

        //Helper Methods
        public List<SelectListItem> GetAllProductSKUs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.ToList().Where(i => i.OwnerId == _userId).Select(p => new SelectListItem
                {
                    Value = p.SKU,
                    Text = p.SKU
                }).ToList();

                return query;
            }
        }
        public List<SelectListItem> GetAllMemberIds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Members.ToList().Where(i => i.OwnerId == _userId).Select(p => new SelectListItem
                {
                    Value = p.MemberId.ToString(),
                    Text = p.FirstName + " " + p.LastName
                }).ToList();

                return query;
            }

        }
    }
}
