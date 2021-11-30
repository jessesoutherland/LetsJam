using LetsJam.Models.Enrollment;
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
    public class EnrollmentController : Controller
    {
        // GET: Enrollment
        public ActionResult Index()
        {
            var svc = CreateEnrollmentService();
            var list = svc.GetAllEnrollments();
            return View(list);
        }
        public ActionResult Create()
        {
            var svc = CreateEnrollmentService();
            ViewBag.Members = svc.GetAllMemberIds();
            ViewBag.Lessons = svc.GetAllLessonIds();
            ViewBag.Skills = svc.GetAllSkills();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(EnrollmentCreate nroll)
        {
            if (!ModelState.IsValid)
                return View(nroll);

            var svc = CreateEnrollmentService();

            if (svc.CreateEnrollment(nroll))
            {
                TempData["SaveResult"] = "The member has been enrolled.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The member was not able to be enrolled.");
            return View(nroll);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateEnrollmentService();
            var query = svc.GetEnrollmentById(id);
            return View(query);
        }
        public ActionResult Edit(int id)
        {
            var svc = CreateEnrollmentService();
            var query = svc.GetEnrollmentById(id);
            ViewBag.Members = svc.GetAllMemberIds();
            ViewBag.Lessons = svc.GetAllLessonIds();
            ViewBag.Skills = svc.GetAllSkills();
            var model = new EnrollmentEdit
            {
                EnrollmentId = query.EnrollmentId,
                MemberId = query.MemberId,
                LessonId = query.LessonId,
                DifficultyLevel = query.DifficultyLevel
            };

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(EnrollmentEdit nroll)
        {
            if (!ModelState.IsValid)
                return View(nroll);

            var svc = CreateEnrollmentService();

            if (svc.UpdateEnrollment(nroll))
            {
                TempData["SaveResult"] = "The enrollment has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The enrollment was unable to update.");
            return View(nroll);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateEnrollmentService();

            var query = svc.GetEnrollmentById(id);

            return View(query);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateEnrollmentService();

            svc.DeleteEnrollment(id);

            TempData["SaveResult"] = "The enrollment was deleted.";

            return RedirectToAction("Index");
        }

        private EnrollmentService CreateEnrollmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new EnrollmentService(userId);
            return svc;
        }
        
    }
}