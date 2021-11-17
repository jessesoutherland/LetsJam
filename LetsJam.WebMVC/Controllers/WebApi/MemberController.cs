using LetsJam.Models.Member;
using LetsJam.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace LetsJam.WebMVC.Controllers.WebApi
{
    [Authorize]
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private bool SetStudentState(int memberId, bool newState)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MemberService(userId);

            var detail = service.GetMemberById(memberId);

            var updatedMember =
                new MemberEdit
                {
                    MemberId = detail.MemberId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Email = detail.Email,
                    Phone =  detail.Phone,
                    IsStudent = newState
                };
            return service.UpdateMember(updatedMember);
        }
        [Route("{id}/student")]
        [HttpPut]
        public bool ToggleStudentOn(int id) => SetStudentState(id, true);

        [Route("{id}/student")]
        [HttpDelete]
        public bool ToggleStudentOff(int id) => SetStudentState(id, false);
    }
}