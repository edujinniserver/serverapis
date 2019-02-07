using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class AssignmentController : ApiController
    {

        EdujinniEntity enty = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingAssignments")]
        public IHttpActionResult addingAssignments(assignment_details adding)
        {

            Boolean d = new AssignmentDetailsRelated().addingAssignDetails(adding);

            if (d)
            {
                adding.insert_date = DateTime.Now;
                enty.assignment_details.Add(adding);
                enty.SaveChanges();

                rs.code = 200;
                rs.message = "succesfully data has been deleted";

                return Content(HttpStatusCode.OK, rs);

            }
            else
            {
                rs.code = 200;
                rs.message = "failed to insert data";

                return Content(HttpStatusCode.OK, rs);
            }

        }



        //below code for assignments list with comparing the three foreignkey tables columns 
        [HttpPost]
        [Route("assignmentsList")]
        public ResponseMessage getAssignmentsList(assignment_details adding)
        {
            var entryPoint = (from ep in enty.assignment_details
                              join e in enty.school_details on adding.school_id equals e.school_id
                              join t in enty.teacher_details on adding.teacher_id equals t.teacher_id
                              join s in enty.student_details on adding.student_id equals s.student_id
                              where ep.assignment_class == adding.assignment_class
                              where ep.school_id == adding.school_id
                              select new
                              {
                                  ep.assignment_enter_topic,
                                  ep.assignment_from_date,
                                  ep.assignment_class,
                                  ep.assignment_section,
                                  ep.assignment_subject,
                                  ep.assignment_to_date,
                                  ep.assignment_related_test,
                                  e.school_name
                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }



    }
}
