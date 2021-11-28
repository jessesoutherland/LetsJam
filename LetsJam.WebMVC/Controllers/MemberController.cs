using LetsJam.Data;
using LetsJam.Models;
using LetsJam.Models.Member;
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
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            MemberService svc = CreateMemberService();
            var list = svc.GetAllMembers();
            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(MemberCreate member)
        {
            if (!ModelState.IsValid)
                return View(member);

            var svc = CreateMemberService();

            if (svc.CreateMember(member))
            {
                TempData["SaveResult"] = "The member was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "The member could not be created.");

            return View(member);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMemberService();

            var model = svc.GetMemberById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateMemberService();
            var member = svc.GetMemberById(id);
            var model = new MemberEdit
            {
                MemberId = member.MemberId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone = member.Phone
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(MemberEdit member)
        {
            if (!ModelState.IsValid) return View(member);

            var service = CreateMemberService();

            if (service.UpdateMember(member))
            {
                TempData["SaveResult"] = "The member was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "The member could not be updated.");

            return View(member);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateMemberService();

            var model = svc.GetMemberById(id);

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateMemberService();

            svc.DeleteMember(id);

            TempData["SaveResult"] = "The member was deleted";

            return RedirectToAction("Index");
        }

        private MemberService CreateMemberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new MemberService(userId);
            return svc;
        }
    }
}