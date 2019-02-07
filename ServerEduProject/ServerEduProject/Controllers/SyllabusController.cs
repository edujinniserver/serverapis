using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class SyllabusController : ApiController
    {
        EdujinniEntity entt = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingSyllabus")]
        public IHttpActionResult addingSyllabus(syllabus_details syllabus)
        {
            Boolean sp = new SyllabusDetailsRelated().addingSyllabus(syllabus);
            
            if (sp)
            {
                syllabus.insert_date = DateTime.Now;
                entt.syllabus_details.Add(syllabus);
                entt.SaveChanges();

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
        [Route("syllabusList")]
        public ResponseMessage syllabusList(syllabus_details slist)
        {
            var entryPoint = (from ep in entt.syllabus_details
                              join e in entt.school_details on slist.school_id equals e.school_id
                              where ep.syllabus_class == slist.syllabus_class
                              where ep.school_id == slist.school_id
                              select new
                              {
                                  ep.syllabus_class,
                                  ep.syllabus_subject,
                                  ep.syllabus_subunit,
                                  ep.syllabus_topic,
                                  ep.syllabus_unit,
                                  ep.update_by,
                                  ep.update_date,
                                  ep.school_id

                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }


        [HttpPost]
        [Route("updateSyllabus")]
        public IHttpActionResult updateSyllabus(syllabus_details update)
        {
            Boolean v = new SyllabusDetailsRelated().updateSyllabus(update);
            
            if (v)
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
    }
}
