using LetsJam.Data;
using LetsJam.Models.Transaction;
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
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            TransactionService svc = CreateTransactionService();
            var model = svc.GetAllTransactions();
            return View(model);
        }
        public ActionResult Create()
        {
            //var svc = CreateTransactionService();
            //ViewBag.Products = svc.GetAllProductSKUs();
            //ViewBag.Members = svc.GetAllMemberIds();
            CreateViewBags();
            return View();
        }
        public void CreateViewBags()
        {
            var svc = CreateTransactionService();
            ViewBag.Products = svc.GetAllProductSKUs();
            ViewBag.Members = svc.GetAllMemberIds();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate trans)
        {
            var svc = CreateTransactionService();
           
            if (!ModelState.IsValid)
                return View(trans);

            var stock = svc.CheckStock(trans);

            if (stock == 0)
            {
                ModelState.AddModelError("", "Product out of stock.");
                CreateViewBags();
                return View(trans);
            }

            if (stock < trans.NumberOfProductPurchased && stock == 1)
            {
                ModelState.AddModelError("", "SORRY! There is currently only " + stock + " in stock.");
                CreateViewBags();
                return View(trans);
            }

            if (stock < trans.NumberOfProductPurchased)
            {
                ModelState.AddModelError("", "SORRY! There are currently only " + stock + " in stock.");
                CreateViewBags();
                return View(trans);
            }

            //svc.UpdateStock(trans);

            if (svc.CreateTransaction(trans))
            {
                TempData["SaveResult"] = "*The transaction was completed.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be completed.");
            return View(trans);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = CreateTransactionService();
            var trans = svc.GetTransactionById(id);
            ViewBag.Products = svc.GetAllProductSKUs();
            ViewBag.Members = svc.GetAllMemberIds();
            var model = new TransactionEdit
            {
                TransactionId = trans.TransactionId,
                SKU = trans.SKU,
                MemberId = trans.MemberId,
                NumberOfProductPurchased = trans.NumberOfProductPurchased
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionEdit trans)
        {
            if (!ModelState.IsValid) return View(trans);

            var svc = CreateTransactionService();

            if (svc.UpdateTransaction(trans))
            {
                TempData["SaveResult"] = "The transaction was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The transaction could not be updated.");

            return View(trans);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateTransactionService();
            var model = svc.GetTransactionById(id);
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken,ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateTransactionService();

            svc.DeleteTransaction(id);

            TempData["SaveResult"] = "The transaction was deleted";

            return RedirectToAction("Index");
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new TransactionService(userId);
            return svc;
        }
    }
}