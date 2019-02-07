using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class ExamResultsController : ApiController
    {
        EdujinniEntity entitys = new EdujinniEntity();
        ResponseMessage rss = new ResponseMessage();

        [HttpPost]
        [Route("addingExamResults")]
        public IHttpActionResult addingExams(exam_results eresults)
        {            
            Boolean gg = new ExamResultsRelated().addingExamResults(eresults);
            if (gg)
            {
                eresults.insert_date = DateTime.Now.ToString();
                entitys.exam_results.Add(eresults);
                entitys.SaveChanges();

                rss.code = 200;
                rss.message = "succesfully data has been inserted";
                return Content(HttpStatusCode.OK, rss);

            }
            else
            {
                rss.code = 100;
                rss.message = "failed to insert data";
                return Content(HttpStatusCode.OK, rss);
            }                  
        }

        
        [HttpPost]
        [Route("examsResultsList")]
        public ResponseMessage examResulList(exam_results sdetails)
        {
            var query = (from staff in entitys.exam_results
                         join section in entitys.exam_details on sdetails.exam_id equals section.exam_id
                         where sdetails.student_id == staff.student_id
                         where sdetails.exam_id == staff.exam_id
                         where sdetails.teacher_id == staff.teacher_id
                         select new
                         {
                             staff.examresult_marks,
                             staff.examresult_subjects,
                             staff.examresult_total_marks,
                             staff.examresult_unit,
                             staff.exam_id,
                             staff.teacher_id,
                             staff.student_id

                         }
                         );
            rss.Data = query;
            rss.code = 200;
            rss.message = "Data success";
            return rss;
        }




        [HttpPost]
        [Route("updateExamResultss")]
        public IHttpActionResult updatings(exam_results eresults)
        {
            Boolean mm = new ExamResultsRelated().updateExamResults(eresults);
            if (mm)
            {
                rss.code = 200;
                rss.message = "succesfully data has been updated";
                return Content(HttpStatusCode.OK, rss);
            }
            else
            {
                rss.code = 100;
                rss.message = "failed to update";
                return Content(HttpStatusCode.OK, rss);
            }
        }




    }
}
