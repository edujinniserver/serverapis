using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class ExamSubjectsController : ApiController
    {
        EdujinniEntity enty = new EdujinniEntity();

        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingExamSubjects")]
        public IHttpActionResult addingExamSubjects(examsubject_details esub)
        {

            Boolean vv = new ExamSubjectsDetailsRelated().addExamSubjDetails(esub);


            if (vv)
            {
                esub.insert_date = DateTime.Now;
                enty.examsubject_details.Add(esub);
                enty.SaveChanges();

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
        [Route("examSubjectsList")]
        public ResponseMessage examSubjectsList(examsubject_details esub)
        {
            var entryPoint = (from ep in enty.examsubject_details
                              //join e in enty.school_details on esub.school_id equals e.school_id
                              where ep.school_id == esub.school_id
                              where ep.exam_id == esub.exam_id
                              where ep.examclass_id == esub.examclass_id
                              where ep.class_id == esub.class_id
                              where ep.section_id==esub.section_id
                              select new
                              {
                                 ep.examsubject_subject_name,
                                 ep.examsubject_subject_type,
                                 ep.examsubject_marks,
                                 ep.examsubject_date,
                                 ep.examsubject_id,
                                 ep.examsubject_start_time,
                                 ep.examsubject_end_time,
                                 ep.examsubject_syllabus,
                                 exam_type=(from exam in enty.examclass_details
                                            where ep.class_id==exam.examclass_id
                                            select new
                                            {
                                                exam.examclass_exam_type,
                                                exam.examclass_class
                                                
                                            })
                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;

        }




        [HttpPost]
        [Route("updateExamSubjects")]
        public IHttpActionResult updateExamsSub(examsubject_details eupdate)
        {
            Boolean up = new ExamSubjectsDetailsRelated().updateExamSubjectsList(eupdate);
            
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
        [Route("deleteExamSubjects")]
        public IHttpActionResult deleteExamSub(examsubject_details ss)
        {
            Boolean h = new ExamSubjectsDetailsRelated().deleteExams(ss);

            if(h)
            {
                rs.code = 200;
                rs.message = "succesfully deleted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failed to delete";
                return Content(HttpStatusCode.OK, rs);
            }
        }




    }
}
