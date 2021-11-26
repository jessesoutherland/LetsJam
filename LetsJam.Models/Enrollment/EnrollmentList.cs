using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Enrollment
{
    public class EnrollmentList
    {
        public int EnrollmentId { get; set; }
        public string MemberName { get; set; }
        public string Instrument { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
