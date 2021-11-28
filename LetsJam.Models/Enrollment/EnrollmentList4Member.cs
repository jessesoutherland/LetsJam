using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Enrollment
{
    public class EnrollmentList4Member
    {
        public string Instrument { get; set; }

        [Display(Name = "Skill Level")]
        public string DifficultyLevel { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

    }
}
