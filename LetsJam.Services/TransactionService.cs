using LetsJam.Data;
using LetsJam.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(model);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TransactionList> GetAllTransactions()
        {
            using(var ctx = new ApplicationDbContext())
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
    }
}
