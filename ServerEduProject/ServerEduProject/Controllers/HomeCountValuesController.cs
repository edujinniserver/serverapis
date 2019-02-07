using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class HomeCountValuesController : ApiController
    {

        EdujinniEntity enty = new EdujinniEntity();
        ResponseMessage1 rs = new Models.ResponseMessage1();

        [HttpPost]
        [Route("homeScreenCount")]
        public IHttpActionResult homeScreenCount(school_details scl)
        {            
            var studets_count = (from a in enty.student_details

                          where a.school_id==scl.school_id
                          select a.student_father_name
                          ).Count();

            var teachers_count = (from a in enty.teacher_details
                          where a.school_id == scl.school_id
                          select a.teacher_first_name
                          ).Count();


            //var sections_count = (from a in enty.Sections
            //                      where a.school_id == scl.school_id
            //                      select a.section_name
            //              ).Count();

            //var classes_count = (from a in enty.class_details
            //                      where a.school_id == scl.school_id
            //                      select a.class_name
            //              ).Count();

            //var exams_count = (from a in enty.exam_details
            //                      where a.school_id == scl.school_id
            //                      select a.exam_type
            //              ).Count();

            //var class_exams_count = (from a in enty.examclass_details
            //                      where a.school_id == scl.school_id
            //                      select a.examclass_class
            //              ).Count();


            rs.studentsCount = studets_count;
            rs.teacherssCount = teachers_count;            
            return Content(HttpStatusCode.OK, rs);
        }

    }
}
