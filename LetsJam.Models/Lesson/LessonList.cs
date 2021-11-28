using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Lesson
{
    public class LessonList
    {
        [Display(Name = "Lesson ID")]
        public int LessonId { get; set; }
        public string Instrument { get; set; }
    }
}
