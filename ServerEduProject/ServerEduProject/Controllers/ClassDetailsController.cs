using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class ClassDetailsController : ApiController
    {

        EdujinniEntity entity = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingClassDetails")]
        public IHttpActionResult addindClasses(class_details addclass)
        {
            Boolean v = new AddingClassDetails().addingClassDetails(addclass);
            if (v)
            {
                addclass.insert_date = DateTime.Now;
                entity.class_details.Add(addclass);
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
        [Route("classDetailsList")]
        public ResponseMessage getEventsDetails(class_details sdetails)
        {
            string tname;

            if (sdetails.class_id!=0 && sdetails.school_id!=0)
            {
                var query = (from section in entity.class_details
                             join tlist in entity.teacher_details on section.teacher_id equals tlist.teacher_id
                             where section.school_id == sdetails.school_id
                             where section.class_id== sdetails.class_id
                             select new
                             {
                                 section.class_id,
                                 section.class_name,
                                 section.class_section_name,
                                 section.insert_by,
                                 section.section_id,
                                 section.insert_date,
                                 section.update_by,
                                 section.update_date,
                                 tname = tlist.teacher_first_name + "" + tlist.teacher_last_name,
                                 section.school_id,
                                 section.teacher_id
                             }
                         );
                rs.Data = query;
                rs.code = 200;
                rs.message = "Data success";
                return rs;
            }
            else if(sdetails.school_id!=0)
            {
                var query = (from section in entity.class_details
                             join tlist in entity.teacher_details on section.teacher_id equals tlist.teacher_id
                             where section.school_id == sdetails.school_id
                             //where tlist.class_id==section.class_id
                             select new
                             {
                                 section.class_id,
                                 section.class_name,
                                 section.class_section_name,
                                 section.insert_by,
                                 section.section_id,
                                 section.insert_date,
                                 section.update_by,
                                 section.update_date,
                                 tname = tlist.teacher_first_name + "" + tlist.teacher_last_name,
                                 section.school_id,
                                 section.teacher_id
                             }
                         );
                rs.Data = query;
                rs.code = 200;
                rs.message = "Data success";
                return rs;
            }else
            {                
                rs.code = 100;
                rs.message = "enter proper details";
                return rs;
            }            
        }


        [HttpPost]
        [Route("deletingClass")]
        public IHttpActionResult deletingClassDeails(class_details del)
        {
            Boolean b = new AddingClassDetails().deletingClassDetails(del);
            if (b)
            {
                rs.code = 200;
                rs.message = "succesfully data has been deleted";

                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "No data found";

                return Content(HttpStatusCode.OK, rs);
            }
        }




        [HttpPost]
        [Route("classNames/classDetailsList")]
        public ResponseMessage getsingleClass(class_details ss)
        {
            var query = (from staff in entity.class_details
                         join section in entity.school_details on staff.school_id equals section.school_id
                         where staff.school_id == ss.school_id
                         select new
                         {
                             staff.class_id,
                             staff.class_name
                         }
                         );
            rs.Data = query;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }




        [HttpPost]
        [Route("updateClassDetails")]
        public IHttpActionResult updateClasses(class_details cdeta)
        {
            Boolean dd = new AddingClassDetails().updateClasses(cdeta);

            if(dd)
            {
                rs.code = 200;
                rs.message = "succesfully data has been updated";

                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failure to update";

                return Content(HttpStatusCode.OK, rs);
            }
        }


    }
}
