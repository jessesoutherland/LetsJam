using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Data
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }

        [Required]
        [ForeignKey(nameof(Lesson))]
        public int LessonId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string DifficultyLevel { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public virtual Member Member { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
