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
        [Display(Name ="Jammer ID")]
        public int MemberId { get; set; }

        [Display(Name="Jammer")]
        public string FullName { get; set; }

        public string LastName { get; set; }

        [UIHint("Student")]
        [Display(Name ="Student?")]
        public bool IsStudent { get; set; }
    }
}
