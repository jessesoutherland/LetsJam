using LetsJam.Models.Lesson;
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
    public class LessonController : Controller
    {
        // GET: Lesson
        public ActionResult Index()
        {
            var svc = CreateLessonService();
            var list = svc.GetAllLessons();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(LessonCreate lesson)
        {
            if (!ModelState.IsValid)
                return View(lesson);

            var svc = CreateLessonService();

            if (svc.CreateLesson(lesson))
            {
                TempData["SaveResult"] = "The lesson was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The lesson could not be created.");
            return View(lesson);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateLessonService();
            var model = svc.GetLessonById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = CreateLessonService();
            var lesson = svc.GetLessonById(id);
            var model = new LessonEdit
            {
                LessonId = lesson.LessonId,
                Instrument = lesson.Instrument,
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(LessonEdit lesson)
        {
            if (!ModelState.IsValid)
                return View(lesson);

            var svc = CreateLessonService();

            if (svc.UpdateLesson(lesson))
            {
                TempData["SaveResult"] = "The lesson was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The lesson could not be updated.");
            return View(lesson);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateLessonService();
            var query = svc.GetLessonById(id);
            return View(query);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            var svc = CreateLessonService();
            svc.DeleteLesson(id);

            TempData["SaveResult"] = "The lesson was deleted";

            return RedirectToAction("Index");
        }

        private LessonService CreateLessonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var svc = new LessonService(userId);
            return svc;
        }
    }
}