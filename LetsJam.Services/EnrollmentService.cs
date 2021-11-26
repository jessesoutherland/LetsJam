using LetsJam.Data;
using LetsJam.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                DifficultyLevel = nroll.DifficultyLevel
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Enrollments.Add(model);

                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EnrollmentList> GetAllEnrollments()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Where(e => e.OwnerId == _userId).Select(e => new EnrollmentList
                {
                    EnrollmentId = e.EnrollmentId,
                    MemberName = e.Member.FirstName + " " + e.Member.LastName,
                    Instrument = e.Lesson.Instrument,
                    DifficultyLevel = e.DifficultyLevel
                });

                return query.ToArray();
            }
        }
        public EnrollmentDetail GetEnrollmentById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Single(e => e.OwnerId == _userId && e.EnrollmentId == id);

                return new EnrollmentDetail
                {
                    EnrollmentId = query.EnrollmentId,
                    MemberId = query.MemberId,
                    MemberName = query.Member.FirstName + " " + query.Member.LastName,
                    LessonId = query.LessonId,
                    Instrument = query.Lesson.Instrument,
                    DifficultyLevel = query.DifficultyLevel
                };
            }
        }
        public bool UpdateEnrollment(EnrollmentEdit nroll)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Single(e => e.OwnerId == _userId && e.EnrollmentId == nroll.EnrollmentId);

                query.EnrollmentId = nroll.EnrollmentId;
                query.MemberId = nroll.MemberId;
                query.LessonId = nroll.LessonId;
                query.DifficultyLevel = nroll.DifficultyLevel;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEnrollment(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Enrollments.Single(e => e.OwnerId == _userId && e.EnrollmentId == id);

                ctx.Enrollments.Remove(query);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
