using LetsJam.Models.Product;
using LetsJam.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LetsJam.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductService svc = CreateProductService();
            var model = svc.GetAllProducts();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate product)
        {
            if (!ModelState.IsValid)
                return View(product);

            var svc = CreateProductService();

            //foreach (string sku in svc.GetAllProductSKUs())
            //{
            //    if (product.SKU == sku)
            //    {
            //        ModelState.AddModelError("", "SKU is already in use.");

            //        return View(product);
            //    }
            //}
            if (svc.CreateProduct(product))
            {
                TempData["SaveResult"] = "The product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");

            return View(product);
        }
        public ActionResult Details(string sku)
        {
            var svc = CreateProductService();
            var model = svc.GetProductBySKU(sku);
            return View(model);
        }

        public ActionResult Edit(string sku)
        {
            var svc = CreateProductService();
            var product = svc.GetProductBySKU(sku);
            var model = new ProductEdit
            {
                SKU = product.SKU,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                NumberInStock = product.NumberInStock
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(string sku, ProductEdit product)
        {
            if (!ModelState.IsValid) return View(product);

            var svc = CreateProductService();

            if (svc.UpdateProduct(product))
            {
                TempData["SaveResult"] = "The product was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The product could not be updated.");

            return View(product);
        }

        [ActionName("Delete")]
        public ActionResult Delete(string sku)
        {
            var svc = CreateProductService();
            var model = svc.GetProductBySKU(sku);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeletePost(string sku)
        {
            var svc = CreateProductService();
            svc.DeleteProduct(sku);

            TempData["SaveResult"] = "The product was deleted.";
            return RedirectToAction("Index");
        }
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new ProductService(userId);
            return svc;
        }

    }
}