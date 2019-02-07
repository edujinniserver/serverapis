using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class TimeTableController : ApiController
    {
        EdujinniEntity entt = new EdujinniEntity();
        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addingTimetable")]
        public IHttpActionResult addingTimeTable(timetable_details addings)
        {
            Boolean sd = new TimeTableRelated().addingTimeTable(addings);

            if (sd)
            {
                addings.insert_date = DateTime.Now;
                entt.timetable_details.Add(addings);
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

        string teacher_name;

        [HttpPost]
        [Route("timeTableList")]
        public ResponseMessage timeTableList(timetable_details slist)
        {
            var entryPoint = (from ep in entt.timetable_details
                                  //join e in entt.school_details on slist.school_id equals e.school_id
                                  //join esub in entt.subject_details on slist.school_id equals esub.school_id
                                  //join eteach in entt.teacher_details on slist.school_id equals eteach.school_id
                                  //join eclass in entt.class_details on eteach.teacher_id equals eclass.teacher_id
                              where ep.timetable_day == slist.timetable_day
                              where ep.school_id == slist.school_id
                              where ep.section_id == slist.section_id
                              where ep.class_id == slist.class_id
                              select new
                              {
                                  ep.timetable_day,
                                  ep.timetable_end_time,
                                  ep.timetable_section,
                                  ep.timetable_start_time,
                                  ep.timetable_id,
                                  ep.subject_id,
                                  ep.teacher_id,
                                  perticularTeacher = (from et in entt.teacher_details
                                                           //join ee in entt.timetable_details on et.teacher_id equals ee.teacher_id
                                                       where et.teacher_id == ep.teacher_id
                                                       select new
                                                       {
                                                           teacher_name = et.teacher_first_name + "" + et.teacher_last_name

                                                       }),
                                  perticularSubject = (from sub in entt.subject_details
                                                       where sub.teacher_id == ep.teacher_id
                                                       select new
                                                       {
                                                           sub.subject_name,
                                                           sub.subject_type
                                                       }),
                                  ep.class_id,
                                  ep.school_id

                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;
        }



        [HttpPost]
        [Route("updateTimeTable")]
        public IHttpActionResult updateTimeTable(timetable_details update)
        {
            Boolean bb = new TimeTableRelated().updateTimeTable(update);

            if (bb)
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
        [Route("deleteTimeTable")]
        public IHttpActionResult deleteTimetable(timetable_details tdel)
        {

            Boolean del = new TimeTableRelated().deleteTimeTbles(tdel);

            if (del)
            {
                rs.code = 200;
                rs.message = "succesfully data has been deleted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failed to delete data";
                return Content(HttpStatusCode.OK, rs);
            }
        }








    }
}