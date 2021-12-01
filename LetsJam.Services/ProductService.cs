using LetsJam.Data;
using LetsJam.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LetsJam.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateProduct(ProductCreate product)
        {
            var model = new Product()
            {
                OwnerId = _userId,
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                NumberInStock = product.NumberInStock
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(model);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductList> GetAllProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Where(p => p.OwnerId == _userId).Select(p => new ProductList
                {
                    SKU = p.SKU,
                    Name = p.Name,
                    Price = p.Price
                });
                return query.ToArray();
            }
           
        }
        public ProductDetail GetProductBySKU(string sku)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Single(p => p.OwnerId == _userId && p.SKU == sku);
                return new ProductDetail
                {
                    SKU = query.SKU,
                    Name = query.Name,
                    Description = query.Description,
                    Price = query.Price,
                    NumberInStock = query.NumberInStock,
                    Transactions = query.Transactions.Select(t => new TransactionList4Product
                    {
                        TransactionId = t.TransactionId,
                        MemberName = t.Member.FirstName + " " + t.Member.LastName,
                        NumberOfProductPurchased = t.NumberOfProductPurchased,
                        DateOfTransaction = t.DateOfTransaction
                    }).ToList()
                };
            }
        }
        public bool UpdateProduct(ProductEdit product)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Single(p => p.SKU == product.SKU && p.OwnerId == _userId);

                query.Name = product.Name;
                query.Description = product.Description;
                query.Price = product.Price;
                query.NumberInStock = product.NumberInStock;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(string sku)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Single(p => p.SKU == sku && p.OwnerId == _userId);

                ctx.Products.Remove(query);

                return ctx.SaveChanges() == 1;
            }
        }
        //public List<SelectListItem> GetAllProductSKUs()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var query = ctx.Products.ToList().Where(i => i.OwnerId == _userId).Select(p => new List<string>
        //    }
        //}
    }
}
