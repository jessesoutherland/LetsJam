using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models
{
    public class MemberList
    {
        [Display(Name ="Member ID")]
        public int MemberId { get; set; }

        [Display(Name="Name")]
        public string FullName { get; set; }

        [UIHint("Student")]
        [Display(Name ="Current Student")]
        public bool IsStudent { get; set; }
    }
}
