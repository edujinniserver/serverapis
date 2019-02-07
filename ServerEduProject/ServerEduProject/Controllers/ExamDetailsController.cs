using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class ExamDetailsController : ApiController
    {
        EdujinniEntity entity = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();


        [HttpPost]
        [Route("addingExams")]
        public IHttpActionResult addingExamClasses(exam_details exdetails)
        {
            Boolean ww = new ExamDetailsRelated().addingExamClassDetails(exdetails);

            if (ww)
            {
                exdetails.insert_date = DateTime.Now;
                entity.exam_details.Add(exdetails);
                entity.SaveChanges();
                rs.code = 200;
                rs.message = "succesfully data has inserted";
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
        [Route("examsList")]
        public ResponseMessage timeTableList(exam_details slist)
        {
            var entryPoint = (from ep in entity.exam_details
                              join e in entity.school_details on slist.school_id equals e.school_id
                              where ep.school_id == slist.school_id                              
                              select new
                              {
                                  ep.exam_type,
                                  ep.exam_start_date,
                                  ep.exam_end_date,                                  
                                  ep.school_id,
                                  ep.exam_id
                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }


        [HttpPost]
        [Route("updateExam")]
        public IHttpActionResult updateExamClass(exam_details edupdate)
        {
            Boolean up = new ExamDetailsRelated().updateExamClassDetails(edupdate);
            if (up)
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



        [HttpPost]
        [Route("deleteExam")]
        public IHttpActionResult deleteExam(exam_details eds)
        {
            Boolean rr = new ExamDetailsRelated().deleteExam(eds);
            if(rr)
            {
                rs.code = 200;
                rs.message = "succesfully data has been deleted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failed to delte";
                return Content(HttpStatusCode.OK, rs);
            }
        }

    }
}
