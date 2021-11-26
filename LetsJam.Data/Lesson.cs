using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Data
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Instrument { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
