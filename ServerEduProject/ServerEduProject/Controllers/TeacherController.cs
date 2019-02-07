using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class TeacherController : ApiController
    {
        EdujinniEntity entt = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingTeacher")]
        public IHttpActionResult addingTeacher(teacher_details adding)
        {
            Boolean g = new TeacherDetails().addingTeacher(adding);

            if (g)
            {
                adding.insert_date = DateTime.Now;
                entt.teacher_details.Add(adding);
                entt.SaveChanges();
                rs.code = 200;
                rs.message = "successfully data has been added";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "Failed to insert data";
                return Content(HttpStatusCode.OK, rs);
            }
        }

        string teacher_first_names;


        [HttpPost]
        [Route("particular/Teacher")]
        public ResponseMessage getTeachersList(teacher_details tlist)
        {


            //if (tlist.teacher_teacherid == null)
            //{
            //    rs.code = 100;
            //    rs.message = "enter correct teacher_teacherId value";
            //    return rs;
            //}
            //else
            //{                
                var entryPoint = (from ep in entt.teacher_details
                                  //join es in entt.class_details on ep.teacher_id equals es.teacher_id                                  
                              where tlist.school_id == ep.school_id
                              where ep.teacher_id == tlist.teacher_id
                              select new
                              {

                                  ep.teacher_teacherid,
                                  ep.teacher_area,
                                  ep.teacher_city,
                                  ep.teacher_date_of_joining,
                                  ep.teacher_department,
                                  ep.teacher_dob,
                                  ep.teacher_email,
                                  ep.teacher_first_name,
                                  ep.insert_by,
                                  ep.insert_date,
                                  ep.school_id,
                                  ep.teacher_flat_no,
                                  ep.teacher_gender,
                                  ep.teacher_image,
                                  ep.teacher_last_name,                                 
                                  ep.teacher_pincode,
                                  ep.teacher_phone_no,
                                  ep.teacher_qualification,
                                  ep.teacher_state,
                                  ep.teacher_street,
                                  ep.teacher_subject1,
                                  ep.teacher_subject2,
                                  ep.teacher_status,
                                  ep.teacher_id,
                                  AllocatedClasses = (from es in entt.class_details 
                                                      where ep.teacher_id==es.teacher_id
                                                      select new
                                                      {
                                                          es.class_name,
                                                          es.class_section_name
                                                      })
                              });                                                   
                rs.Data = entryPoint;
                rs.code = 200;
                rs.message = "Data success";
                return rs;                         
            //}
          
        }

        public string teacher_fullname;

        [HttpPost]
        [Route("teachersList")]
        public ResponseMessage getTeachersListIndi(teacher_details tlist)
        {            

            var entryPoint = (from ep in entt.teacher_details
                              join e in entt.school_details on ep.school_id equals e.school_id
                              //join t in enty.class_details on tlist.class_id equals t.class_id
                              where tlist.school_id == ep.school_id
                              select new
                              {
                                  ep.teacher_id,
                                  teacher_fullname = ep.teacher_first_name+ep.teacher_last_name,
                                  ep.teacher_subject1,
                                  ep.teacher_phone_no,
                                  ep.school_id,
                                  ep.teacher_teacherid

                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }


        //[HttpPost]
        //[Route("perticular/Teacher/classes")]
        //public ResponseMessage perticularTeacher(teacher_details tlist)
        //{
        //    var entryPoint = (from ep in entt.teacher_details
        //                      join e in entt.school_details on ep.school_id equals e.school_id
        //                      join eclass in entt.class_details on ep.teacher_id equals eclass.teacher_id
        //                      where tlist.school_id == ep.school_id
        //                      where tlist.teacher_teacherid == ep.teacher_teacherid                             
        //                      select new
        //                      {
        //                          ep.teacher_area,
        //                          ep.teacher_city,
        //                          ep.teacher_date_of_joining,
        //                          ep.teacher_department,
        //                          ep.teacher_dob,
        //                          ep.teacher_email,
        //                          ep.teacher_first_name,
        //                          ep.insert_by,
        //                          ep.insert_date,
        //                          ep.school_id,
        //                          ep.teacher_flat_no,
        //                          ep.teacher_teacherid,
        //                          ep.teacher_gender,
        //                          ep.teacher_image,
        //                          ep.teacher_last_name,
        //                          ep.teacher_pincode,
        //                          ep.teacher_phone_no,
        //                          ep.teacher_qualification,
        //                          ep.teacher_state,
        //                          ep.teacher_street,
        //                          ep.teacher_subject1,
        //                          ep.teacher_status,
        //                          ep.teacher_subject2,
        //                          ep.teacher_id,
        //                          e.school_name,
        //                          eclass.class_id,
        //                          eclass.class_name,
        //                      });
        //    rs.Data = entryPoint;
        //    rs.code = 200;
        //    rs.message = "Data success";
        //    return rs;
        //}











        [HttpPost]
        [Route("updateTeacher")]
        public IHttpActionResult updateTeacher(teacher_details tda)
        {

            Boolean bb = new TeacherDetails().updateTeacher(tda);


            if (bb)
            {
                rs.code = 200;
                rs.message = "succesfully data has updated";
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
        [Route("deleteTeacher")]
        public IHttpActionResult deleteTeacher(teacher_details tlist)
        {
            Boolean bb = new TeacherDetails().deleteTeacher(tlist);
            if (bb)
            {
                rs.code = 200;
                rs.message = "succesfully data has deleted";
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
