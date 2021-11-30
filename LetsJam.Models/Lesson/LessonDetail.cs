using LetsJam.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Lesson
{
    public class LessonDetail
    {
        [Display(Name = "Lesson ID:")]
        public int LessonId { get; set; }

        [Display(Name ="Instrument:")]
        public string Instrument { get; set; }
        public virtual ICollection<EnrollmentList4Lesson> Enrollments { get; set; }

    }
}
