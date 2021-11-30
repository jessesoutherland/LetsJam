using LetsJam.Data;
using LetsJam.Models.Enrollment;
using LetsJam.Models.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Services
{
    public class LessonService
    {
        private readonly Guid _userId;

        public LessonService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLesson(LessonCreate lesson)
        {
            var model = new Lesson()
            {
                OwnerId = _userId,
                Instrument = lesson.Instrument,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Lessons.Add(model);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LessonList> GetAllLessons()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Lessons.Where(l => l.OwnerId == _userId).Select(l => new LessonList
                {
                    LessonId = l.LessonId,
                    Instrument = l.Instrument,
                });

                return query.ToArray();
            }
        }
        public LessonDetail GetLessonById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Lessons.Single(l => l.OwnerId == _userId && l.LessonId == id);

                return new LessonDetail
                {
                    LessonId = query.LessonId,
                    Instrument = query.Instrument,
                    Enrollments = query.Enrollments.Select(e => new EnrollmentList4Lesson
                    {
                        EnrollmentId = e.EnrollmentId,
                        StudentName = e.Member.FirstName + " " + e.Member.LastName,
                        DifficultyLevel = e.DifficultyLevel
                    }).ToList()
                };
            }
        }
        public bool UpdateLesson(LessonEdit lesson)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Lessons.Single(l => l.OwnerId == _userId && l.LessonId == lesson.LessonId);

                query.Instrument = lesson.Instrument;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLesson(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Lessons.Single(l => l.OwnerId == _userId && l.LessonId == id);

                ctx.Lessons.Remove(query);

                return ctx.SaveChanges() == 1;
            }
        }
    
    }
}
