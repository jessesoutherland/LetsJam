using LetsJam.Data;
using LetsJam.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LetsJam.Services
{
    public class EnrollmentService
    {
        private readonly Guid _userId;
        public EnrollmentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEnrollment(EnrollmentCreate nroll)
        {
            var model = new Enrollment
            {
                OwnerId = _userId,
                MemberId = nroll.MemberId,
                LessonId = nroll.LessonId,
                DifficultyLevel = nroll.DifficultyLevel,
                StartDate = nroll.StartDate
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Enrollments.Add(model);
                Member student = ctx.Members.Find(nroll.MemberId);
                student.IsStudent = true;

                return ctx.SaveChanges() == 2;
            }
        }
        public IEnumerable<EnrollmentList> GetAllEnrollments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Where(e => e.OwnerId == _userId).Select(e => new EnrollmentList
                {
                    EnrollmentId = e.EnrollmentId,
                    StudentName = e.Member.FirstName + " " + e.Member.LastName,
                    Instrument = e.Lesson.Instrument,
                    DifficultyLevel = e.DifficultyLevel,
                });

                return query.ToArray();
            }
        }
        public EnrollmentDetail GetEnrollmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Single(e => e.OwnerId == _userId && e.EnrollmentId == id);

                return new EnrollmentDetail
                {
                    EnrollmentId = query.EnrollmentId,
                    MemberId = query.MemberId,
                    StudentName = query.Member.FirstName + " " + query.Member.LastName,
                    LessonId = query.LessonId,
                    Instrument = query.Lesson.Instrument,
                    DifficultyLevel = query.DifficultyLevel,
                    StartDate = query.StartDate
                };
            }
        }
        public bool UpdateEnrollment(EnrollmentEdit nroll)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Single(e => e.OwnerId == _userId && e.EnrollmentId == nroll.EnrollmentId);

                query.EnrollmentId = nroll.EnrollmentId;
                query.MemberId = nroll.MemberId;
                query.LessonId = nroll.LessonId;
                query.DifficultyLevel = nroll.DifficultyLevel;
                query.StartDate = nroll.StartDate;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEnrollment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Single(e => e.OwnerId == _userId && e.EnrollmentId == id);

                ctx.Enrollments.Remove(query);

                return ctx.SaveChanges() == 1;
            }
        }

        public List<SelectListItem> GetAllLessonIds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Lessons.ToList().Select(p => new SelectListItem
                {
                    Value = p.LessonId.ToString(),
                    Text = p.Instrument
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
        public List<SelectListItem> GetAllSkills()
        {
            var sl = new List<SelectListItem>
            {
                new SelectListItem { Text = "Beginner", Value = "Beginner" },
                new SelectListItem { Text = "Intermediate", Value = "Intermediate" },
                new SelectListItem { Text = "Why Are You Here?", Value = "Why Are You Here?" }
            }.ToList();
            return sl;
        }
    }
}


