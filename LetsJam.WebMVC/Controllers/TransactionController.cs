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
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(TransactionCreate trans)
        {
            if (!ModelState.IsValid)
                return View(trans);

            var svc = CreateTransactionService();

            if (svc.CreateTransaction(trans))
            {
                TempData["SaveResult"] = "The transaction was completed.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Transaction could not be completed.");
            return View(trans);
        }

        private TransactionService CreateTransactionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new TransactionService(userId);
            return svc;
        }
    }
}