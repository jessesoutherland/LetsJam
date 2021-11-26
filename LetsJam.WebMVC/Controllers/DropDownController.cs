using LetsJam.Data;
//using LetsJam.Models.DropDown;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//namespace LetsJam.WebMVC.Controllers
//{

//    public class DropDownController : Controller
//    {
//        private TransactionService CreateTransactionService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var svc = new TransactionService(userId);
//            return svc;
//        }
//        private readonly ApplicationDbContext _ctx;

//        public DropdownController(ApplicationDbContext ctx)
//        {
//            _ctx = ctx;
//        }
//        public IActionResult Index()
//        {
//            List<ListOfSKUs> cl = new List<ListOfSKUs>();
//            cl = (from c in _ctx.Products select c).ToList();
//            cl.Insert(0, new ListOfSKUs { SKU = "--Select Country Name--" });
//            ViewBag.message = cl;
//            return View();
//        }
//    }
//}