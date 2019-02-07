using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class EventDetailsController : ApiController
    {

        EdujinniEntity entity = new EdujinniEntity();

        ResponseMessage rs = new ResponseMessage();   

        [HttpPost]
        [Route("addingEvents")]
        public IHttpActionResult addingEvents(event_details addingEventsDetails)
        {
            Boolean b = new EventDetailsRelated().addingEventsDetails(addingEventsDetails);
            if (b)
            {
                addingEventsDetails.insert_date = DateTime.Now;
                entity.event_details.Add(addingEventsDetails);
                entity.SaveChanges();

                rs.code = 200;
                rs.message = "succesfully data has inserted";

                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "fail to insert";

                return Content(HttpStatusCode.OK, rs);
            }
        }


        [HttpPost]
        [Route("updatingEvents")]
        public IHttpActionResult updatingEvents(event_details evdetails)
        {
            Boolean n = new EventDetailsRelated().UpdateEvents(evdetails);
            if (n)
            {
                rs.code = 200;
                rs.message = "succesfully data has updated";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failed to update data";
                return Content(HttpStatusCode.OK, rs);
            }
        }

        [HttpPost]
        [Route("deletingEvents")]
        public IHttpActionResult deletingEvents(event_details secn)
        {
            //if(secn.school_id.Equals(0)|| secn.event_name.Equals(null)|| secn.event_id.Equals(0))
            //{
            //    rs.code = 404;
            //    rs.message = "enter proper details";
            //    return Content(HttpStatusCode.OK, rs);
            //}
            //else
            //{
                Boolean b = new EventDetailsRelated().deleteSection(secn);
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
            //}
           
        }

        [HttpPost]
        [Route("eventsList")]
        public ResponseMessage getEventsDetails(event_details sdetails)
        {
            var query = (from staff in entity.event_details
                         join section in entity.school_details on sdetails.school_id equals section.school_id
                         where staff.school_id == sdetails.school_id
                         select new
                         {
                             staff.event_date,
                             staff.event_description,
                             staff.event_image,
                             staff.event_name,
                             staff.school_id,
                             staff.event_id                             
                         }
                         );


            rs.Data = query;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }


    }
}
