using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class StudentDetailsController : ApiController
    {
        EdujinniEntity entt = new EdujinniEntity();

        ResponseMessage rs = new ResponseMessage();

        public Object ss;
        public Object ss1;


        [HttpPost]
        [Route("addingStudentDetails")]
        public IHttpActionResult addingStudentDetails(student_details sdetails)
        {

            Boolean a = new StudentDetailsRelated().addingStudentDetails(sdetails);

            if (a)
            {
                sdetails.insert_date = DateTime.Now;
                entt.student_details.Add(sdetails);
                entt.SaveChanges();

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

        string student_grade = "A";

        [HttpPost]
        [Route("studentsList")]
        public ResponseMessage getStudentsList(student_details slist)
        {
            if (slist.section_id.Equals(0) || slist.class_id.Equals(0) || slist.school_id.Equals(0))
            {
                rs.code = 100;
                rs.message = "Enter proper details";
                return rs;
            }
            else
            {
                var entryPoint = (from ep in entt.student_details
                                  join e in entt.school_details on slist.school_id equals e.school_id
                                  where ep.school_id == slist.school_id
                                  where ep.class_id == slist.class_id
                                  where ep.section_id == slist.section_id
                                  select new
                                  {
                                      ep.student_image,
                                      ep.student_id,
                                      studentName = ep.student_first_name + ep.student_last_name,
                                      student_grade
                                  });
                rs.Data = entryPoint;
                rs.code = 200;
                rs.message = "Data success";
                return rs;
            }
        }

        [HttpPost]
        [Route("updateStudentDetails")]
        public IHttpActionResult updateStudents(student_details sdetails)
        {
            Boolean pp = new StudentDetailsRelated().updateStudentsList(sdetails);
            if (pp)
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








        [HttpGet]
        [Route("studentNames/studentsList")]
        public ResponseMessage getStudentsNames()
        {
            String studentName;
            var entryPoint = (from ep in entt.student_details
                              join e in entt.school_details on ep.school_id equals e.school_id
                              where ep.school_id == e.school_id
                              //where ep.examsubject_class == slist.examsubject_class
                              //where ep.teacher_id == slist.teacher_id
                              //where ep.class_id == slist.class_id
                              select new
                              {
                                  studentName = ep.student_first_name + ep.student_last_name

                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }

        [HttpPost]
        [Route("perticularStudent")]
        public ResponseMessage perticularStudent(student_details sdata)
        {

            var entryPoint = (from ep in entt.student_details
                              where ep.school_id == sdata.school_id
                              where ep.student_id == sdata.student_id
                              where ep.class_id == sdata.class_id
                              where ep.section_id == sdata.section_id
                              select new
                              {
                                  ep.school_id,
                                  ep.student_admission_date,
                                  ep.student_area,
                                  ep.student_buliding_name,
                                  ep.student_chiled_no,
                                  ep.student_city,
                                  ep.student_dob,
                                  ep.student_father_mobile_no,
                                  ep.student_father_name,
                                  ep.student_father_occupation,
                                  ep.student_first_name,
                                  ep.student_flat_no,
                                  ep.student_gender,
                                  ep.student_image,
                                  ep.student_last_name,
                                  ep.student_mother_mobile_no,
                                  ep.student_mother_name,
                                  ep.student_mother_occupation,
                                  ep.student_no_of_siblings,
                                  ep.student_pincode,
                                  ep.student_roll_no,
                                  ep.student_admission_id,
                                  ep.student_class,
                                  ep.student_section,
                                  ep.student_state,
                                  ep.Student_status,
                                  ep.student_street,
                                  ep.student_street1,
                                  ep.student_id,                                  
                                  ep.class_id,
                                  ep.section_id
                              });

            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }

        [HttpPost]
        [Route("deleteStudent")]
        public IHttpActionResult deleteStudent(student_details sdelete)
        {

            Boolean t = new StudentDetailsRelated().deleteStudent(sdelete);

            if (t)
            {
                rs.code = 200;
                rs.message = "succesfully data has been deleted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failure to delete";
                return Content(HttpStatusCode.OK, rs);
            }
        }





    }
}