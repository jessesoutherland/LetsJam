using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LetsJam.Models.Enrollment
{
    public class EnrollmentList
    {
        public int EnrollmentId { get; set; }

        [Display(Name = "Rock Star")]
        public string StudentName { get; set; }

        public string Instrument { get; set; }

        [Display(Name = "Skill Level")]
        public string DifficultyLevel { get; set; }
    }
}
