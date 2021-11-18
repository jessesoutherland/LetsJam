using LetsJam.Data;
using LetsJam.Models;
using LetsJam.Models.Enrollment;
using LetsJam.Models.Member;
using LetsJam.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsJam.Services
{
    public class MemberService
    {
        private readonly Guid _userId;

        public MemberService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMember(MemberCreate member)
        {
            var model = new Member()
            {
                OwnerId = _userId,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Email = member.Email,
                Phone = member.Phone,
                IsStudent = member.IsStudent
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(model);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MemberList> GetAllMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Members.Where(m => m.OwnerId == _userId).Select(m => new MemberList
                {
                    MemberId = m.MemberId,
                    FullName = m.FirstName + " " + m.LastName,
                    IsStudent = m.IsStudent

                });
                return query.ToArray();
            }
        }

        public MemberDetail GetMemberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Members.Single(m => m.MemberId == id && m.OwnerId == _userId);
                return new MemberDetail
                {
                    MemberId = entity.MemberId,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    FullName = entity.FullName,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    IsStudent = entity.IsStudent,
                    Enrollments = entity.Enrollments.Select(b => new EnrollmentList
                    {
                        //LessonId = b.LessonId,
                        //DifficultyLevel = b.DifficultyLevel,
                    }).ToList(),
                    Transactions = entity.Transactions.Select(t => new TransactionList4Member
                    {
                        TransactionId = t.TransactionId,
                        ProductName = t.Product.Name,
                        DateOfTransaction = t.DateOfTransaction,
                        NumberOfProductPurchased = t.NumberOfProductPurchased
                    }).ToList()
                };
            }
        }

        public bool UpdateMember(MemberEdit member)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Members.Single(m => m.MemberId == member.MemberId && m.OwnerId == _userId);

                query.FirstName = member.FirstName;
                query.LastName = member.LastName;
                query.Email = member.Email;
                query.Phone = member.Phone;
                query.IsStudent = member.IsStudent;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMember(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Members.Single(m => m.MemberId == id && m.OwnerId == _userId);

                ctx.Members.Remove(query);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
