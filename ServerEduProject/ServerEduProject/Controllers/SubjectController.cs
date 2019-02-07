using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class SubjectController : ApiController
    {
        EdujinniEntity entt = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingSubjects")]
        public IHttpActionResult addingSubjects(subject_details sdetails)
        {
            Boolean s = new SubjectDetailsrelated().addSubjectDetails(sdetails);
            if (s)
            {
                sdetails.insert_date = DateTime.Now;
                entt.subject_details.Add(sdetails);
                entt.SaveChanges();

                rs.code = 200;
                rs.message = "succesfully data has been added";
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
        [Route("subjectsList")]
        public ResponseMessage subjectsList(subject_details slist)
        {

            if (slist.school_id.Equals(0) || slist.class_id.Equals(0)|| slist.section_id.Equals(0))
            {
                rs.code = 100;
                rs.message = "enter proper details";
                return rs;
            }
            else
            {
                var entryPoint = (from ep in entt.subject_details                                  
                                  where ep.section_id == slist.section_id
                                  where ep.class_id == slist.class_id
                                  where ep.school_id == slist.school_id                                  
                                  select new
                                  {
                                      ep.section,
                                      ep.subject_id,
                                      ep.subject_type,
                                      ep.subject_name,
                                      ep.school_id,
                                      ep.class_id,
                                      ep.section_id,
                                      



                                      //ep.insert_by,
                                      //ep.insert_date,
                                      //ep.update_by,
                                      //ep.update_date

                                      //classDetails=(from es in entt.class_details
                                      //              where es.class_id== slist.class_id
                                      //              select new
                                      //              {
                                      //                  es.class_name,
                                      //                  es.class_section_name,
                                      //                  es.class_id
                                      //              }),
                                      //              secDetails=(from es in entt.Sections
                                      //                          where es.section_id == slist.section_id
                                      //                          select new
                                      //                          {
                                      //                              es.section_id,
                                      //                              es.section_name
                                      //                          }),
                                      //                          teachers=(from es in entt.teacher_details
                                      //                                    where es.class_id == slist.class_id
                                      //                                    select new
                                      //                                    {
                                      //                                        es.teacher_id,
                                      //                                        es.teacher_first_name
                                      //                                    })

                                  });
                rs.Data = entryPoint;
                rs.code = 200;
                rs.message = "Data success";
                return rs;                
            }
        }


        [HttpPost]
        [Route("updateSubjects")]
        public IHttpActionResult updateSubjects(subject_details sdetails)
        {
            Boolean d = new SubjectDetailsrelated().updatingSubjects(sdetails);
            if (d)
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


/*
        [HttpPost]
        [Route("single/subject")]
        public ResponseMessage singlSubje(subject_details sdetails)
        {
            var entryPoint = (from ep in entt.subject_details
                              join e in entt.school_details on sdetails.school_id equals e.school_id                              
                              where ep.school_id == sdetails.school_id                              
                              select new
                              {
                                  ep.section,
                                  ep.subject_id,
                                  ep.subject_type,
                                  ep.subject_name,                                
                                  ep.school_id,
                                  ep.teacher_id,
                                  ep.class_id
                              });


               rs.Data = entryPoint;
                rs.code = 200;
                rs.message = "Data success";
                return rs;                     
        }

    */
        [HttpPost]
        [Route("deleteSubject")]
        public IHttpActionResult deleteSubject(subject_details sub)
        {
            Boolean gg = new SubjectDetailsrelated().deleteSubjects(sub);


            if(gg)
            {
                rs.code = 200;
                rs.message = "succesfully data has been deleted";
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
