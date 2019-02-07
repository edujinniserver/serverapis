using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class LeaveRequestController : ApiController
    {
        EdujinniEntity entt = new EdujinniEntity();

        ResponseMessage rs = new ResponseMessage();


        [HttpPost]
        [Route("addLeaveRequest")]
        public IHttpActionResult addLeaves(leaverequest leave)
        {
            Boolean m = new LeaveRequestRelated().addLeaveRequest(leave);
            if (m)
            {
                leave.insert_date = DateTime.Now;
                entt.leaverequests.Add(leave);
                entt.SaveChanges();
                rs.code = 200;
                rs.message = "succesfully data has inserted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "Already existed date";
                return Content(HttpStatusCode.OK, rs);
            }


        }


        [HttpPost]
        [Route("viewLeaveRequests")]
        public ResponseMessage getAchievementsList(leaverequest sdetails)
        {
            var query = (from staff in entt.leaverequests
                         join section in entt.school_details on sdetails.school_id equals section.school_id
                         where sdetails.school_id == staff.school_id
                         select new
                         {
                             staff.leaverequest_requested_by,
                             staff.leaverequest_aproved_by,
                             staff.leaverequest_description,
                             staff.leaverequest_from_date,
                             staff.leaverequest_id,
                             staff.leaverequest_status,
                             staff.leaverequest_to_date,
                             staff.school_id,
                             section.update_by,
                             section.update_date
                         }
                         );
            rs.Data = query;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }


    }
}
