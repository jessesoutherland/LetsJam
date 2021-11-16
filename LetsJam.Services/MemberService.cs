using LetsJam.Data;
using LetsJam.Models;
using LetsJam.Models.Member;
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
                var query = ctx.Members.Where(e => e.OwnerId == _userId).Select(e => new MemberList
                {
                    MemberId = e.MemberId,
                    FullName = e.FirstName + " " + e.LastName,
                    IsStudent = e.IsStudent

                });
                return query.ToArray();
            }
        }

        public MemberDetail GetMemberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Members.Single(e => e.MemberId == id && e.OwnerId == _userId);
                return new MemberDetail
                {
                    MemberId = entity.MemberId,
                    FullName = entity.FullName,
                    Email = entity.Email,
                    Phone = entity.Phone,
                    IsStudent = entity.IsStudent,
                    Enrollments = entity.Enrollments.Select(b => new Enrollment
                    {
                        LessonId = b.LessonId,
                        DifficultyLevel = b.DifficultyLevel,
                    }).ToList(),
                    Transactions = entity.Transactions.Select(c => new Transaction
                    {
                        TransactionId = c.TransactionId,
                        SKU = c.SKU,
                        DateOfTransaction = c.DateOfTransaction,
                        NumberOfProductPurchased = c.NumberOfProductPurchased
                    }).ToList()
                };
            }
        }
    }
}
