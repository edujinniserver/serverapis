using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class ExamClassController : ApiController
    {
        EdujinniEntity entity = new EdujinniEntity();
        ResponseMessage rss = new ResponseMessage();


        [HttpPost]
        [Route("addingExamClass")]
        public IHttpActionResult addingExamClasses(examclass_details exdetails)
        {
            Boolean ww = new ExamClassDetails().addingExamClassDetails(exdetails);

            if (ww)
            {
                exdetails.insert_date = DateTime.Now;
                entity.examclass_details.Add(exdetails);
                entity.SaveChanges();

                rss.code = 200;
                rss.message = "succesfully data has inserted";
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
        [Route("examClassList")]
        public ResponseMessage timeTableList(examclass_details slist)
        {
            var entryPoint = (from ep in entity.examclass_details
                              join e in entity.school_details on slist.school_id equals e.school_id
                              where ep.school_id == slist.school_id
                              where ep.examclass_exam_type == slist.examclass_exam_type
                              //where ep.teacher_id == slist.teacher_id
                              //where ep.class_id == slist.class_id
                              select new
                              {
                                  ep.examclass_class,
                                  ep.examclass_section,
                                  ep.examclass_exam_type,
                                  ep.examclass_start_date,
                                  ep.examclass_end_date,
                                  ep.school_id,
                                  ep.examclass_id,
                                  ep.section_id,
                                  ep.class_id                                                                    
                              });
            rss.Data = entryPoint;
            rss.code = 200;
            rss.message = "Data success";
            return rss;
        }


        [HttpPost]
        [Route("updateExamClass")]
        public IHttpActionResult updateExamClass(examclass_details edupdate)
        {
            Boolean up = new ExamClassDetails().updateExamClassDetails(edupdate);
            if (up)
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


        [HttpPost]
        [Route("deleteExamClass")]
        public IHttpActionResult deleteExamClass(examclass_details eclass)
        {
            Boolean s = new ExamClassDetails().deleteClass(eclass);

            if(s)
            {
                rss.code = 200;
                rss.message = "succesfully data hasbeen deleted";
                return Content(HttpStatusCode.OK, rss);
            }
            else
            {
                rss.code = 100;
                rss.message = "failed to delete";
                return Content(HttpStatusCode.OK, rss);
            }
        }



    }
}
