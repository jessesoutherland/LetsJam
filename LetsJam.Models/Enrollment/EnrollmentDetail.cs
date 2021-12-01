using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Enrollment
{
    public class EnrollmentDetail
    {
        [Display(Name = "Enrollment ID:")]
        public int EnrollmentId { get; set; }

        [Display(Name = "Jammer ID:")]
        public int MemberId { get; set; }

        [Display(Name = "Jammer:")]
        public string StudentName { get; set; }

        [Display(Name = "Lesson ID:")]
        public int LessonId { get; set; }

        [Display(Name = "Instrument:")]
        public string Instrument { get; set; }

        [Display(Name = "Skill Level:")]
        public string DifficultyLevel { get; set; }

        [Display(Name = "Start Date:")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    }
}
