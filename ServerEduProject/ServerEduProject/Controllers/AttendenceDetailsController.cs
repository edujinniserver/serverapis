using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class AttendenceDetailsController : ApiController
    {

        EdujinniEntity entity = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingAttendance")]
        public IHttpActionResult addingAttendance( attendence_details addind)
        {
            Boolean ff = new AttendenceDetails().addingAteendance(addind);
            
            if (ff)
            {
                addind.insert_date = DateTime.Now;
                entity.attendence_details.Add(addind);
                entity.SaveChanges();

                rs.code = 200;
                rs.message = "succesfully data has been inserted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {

                rs.code = 100;
                rs.message = "failed to insert data";
                return Content(HttpStatusCode.OK, rs);
            }
        }


        [HttpPost]
        [Route("attendenceList")]
        public ResponseMessage examResulList(attendence_details addind)
        {
            var query = (from staff in entity.attendence_details
                         join section in entity.school_details on addind.school_id equals section.school_id
                         where addind.student_id == staff.student_id
                         where addind.school_id == staff.school_id
                         where addind.class_id == staff.class_id
                         //where addind.attendence_roll_no==staff.attendence_roll_no
                         select new
                         {

                             staff.attendence_parent_name,
                             staff.attendence_roll_no,
                             staff.attendence_section,
                             staff.attendence_setion,
                             staff.attendence_status,
                             staff.school_id,
                             staff.student_id,
                             staff.class_id
                         }
                         );
            rs.Data = query;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }



        [HttpPost]
        [Route("updateAttendence")]
        public IHttpActionResult updateAttendence(attendence_details update)
        {
            Boolean s = new AttendenceDetails().updateAttendence(update);
            if (s)
            {
                rs.code = 200;
                rs.message = "succesfully data has been updated";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failed to update";
                return Content(HttpStatusCode.OK, rs);
            }
        }

    }
}
