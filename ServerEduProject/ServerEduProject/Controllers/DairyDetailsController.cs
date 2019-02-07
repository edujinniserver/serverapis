using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class DairyDetailsController : ApiController
    {

        EdujinniEntity ess = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();




        [HttpPost]
        [Route("addingDairy")]
        public IHttpActionResult addingDairy(dairy_details adding)
        {
            Boolean ss = new DairyDetailsRelated().addingDairyData(adding);
            
            if (ss)
            {
                adding.insert_date = DateTime.Now;
                ess.dairy_details.Add(adding);
                ess.SaveChanges();


                rs.code = 200;
                rs.message = "Data has been added succesfully";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 200;
                rs.message = "data adding failed";
                return Content(HttpStatusCode.OK, rs);
            }
        }

        [HttpPost]
        [Route("dairyList")]
        public ResponseMessage dairyList(dairy_details views)
        {
            var entryPoint = (from ep in ess.dairy_details
                              join e in ess.school_details on views.school_id equals e.school_id
                              join t in ess.teacher_details on views.teacher_id equals t.teacher_id
                              join s in ess.student_details on views.student_id equals s.student_id
                              where ep.dairy_class == views.dairy_class
                              where views.student_id == ep.student_id
                              select new
                              {
                                  ep.dairy_class,
                                  ep.dairy_date,
                                  ep.dairy_section,
                                  ep.dairy_subject,
                                  ep.dairy_todays_homework,
                                  ep.dairy_todays_work,
                                  ep.dairy_units,
                                  ep.insert_by,
                                  ep.insert_date,
                                  ep.school_id,
                                  ep.student_id,
                                  ep.teacher_id,
                                  e.school_name
                              });


            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;

        }




    }
}
