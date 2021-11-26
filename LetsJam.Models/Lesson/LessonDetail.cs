﻿using LetsJam.Models.Enrollment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Lesson
{
    public class LessonDetail
    {
        public int LessonId { get; set; }
        public string Instrument { get; set; }
        public virtual ICollection<EnrollmentList4Lesson> Enrollments { get; set; }

    }
}