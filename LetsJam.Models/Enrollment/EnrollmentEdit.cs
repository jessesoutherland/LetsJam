using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Enrollment
{
    public class EnrollmentEdit
    {
        public int EnrollmentId { get; set; }
        public int MemberId { get; set; }
        public int LessonId { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
