using LetsJam.Data;
using LetsJam.Models.Enrollment;
using LetsJam.Models.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Models.Member
{
    public class MemberDetail
    {
        [Display(Name = "Jammer ID")]
        public int MemberId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Display(Name = "Student?")]
        public bool IsStudent { get; set; }

        public virtual ICollection<EnrollmentList4Member> Enrollments { get; set; }
        public virtual ICollection<TransactionList4Member> Transactions { get; set; }
    }
}
