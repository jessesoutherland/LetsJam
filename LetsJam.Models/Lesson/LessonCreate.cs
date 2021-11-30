using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Lesson
{
    public class LessonCreate
    {
        [Display(Name ="Instrument:")]
        public string Instrument { get; set; }
    }
}
