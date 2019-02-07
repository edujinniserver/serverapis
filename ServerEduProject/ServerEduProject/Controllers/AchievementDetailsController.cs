using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    //[RoutePrefix("achievements")]
    public class AchievementDetailsController : ApiController
    {

        EdujinniEntity entity = new EdujinniEntity();

        ResponseMessage response = new ResponseMessage();

        [HttpPost]
        [Route("addAchievements")]
        public IHttpActionResult addings(Achievement_details addings)
        {
            Boolean b = new AchevementDetailsRelated().addingAchievemnts(addings);

            if(b)
            {
                addings.insert_date = DateTime.Now;
                entity.Achievement_details.Add(addings);
                entity.SaveChanges();

                response.code = 200;
                response.message = "succesfully data has been inserted";

                return Content(HttpStatusCode.OK, response);

            }
            else
            {
                response.code = 200;
                response.message = "succesfully data has been inserted";
                return Content(HttpStatusCode.OK, response);
            }
        }


        [HttpPost]
        [Route("achievementList")]
        public ResponseMessage achiementsList(Achievement_details sdetails)
        {
            var query = (from staff in entity.Achievement_details
                         //join section in entity.school_details on sdetails.school_id equals section.school_id
                         where sdetails.school_id == staff.school_id
                         where sdetails.class_id == staff.class_id
                         where sdetails.section_id == staff.section_id
                         select new
                         {
                             staff.achievement_type,
                             staff.achievement_section,
                             staff.achievement_id,
                             staff.achievement_date,
                             staff.achievement_description,
                             staff.achievement_student_name,
                             classNames=(from cls in entity.class_details 
                                        where cls.class_id == sdetails.class_id
                                        select new
                                        {
                                            cls.class_name,                                            
                                        }) ,
                                        
                                        sectionName=(from cls in entity.Sections
                                                     where cls.section_id == sdetails.section_id
                                                     select new
                                                     {
                                                         cls.section_name,                                                         
                                                     })                                                            
                         }
                        );
            response.Data = query;
            response.code = 200;
            response.message = "Data success";
            return response;
        }




        [HttpPost]
        [Route("updateAchievement")]
        public IHttpActionResult updateAchievements(Achievement_details alist)
        {
            Boolean g = new AchevementDetailsRelated().updateAchievements(alist);

            if(g)
            {
                response.code = 200;
                response.message = "succesfully data has updated";
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                response.code = 100;
                response.message = "failed to update";
                return Content(HttpStatusCode.OK, response);
            }
        }


            [HttpPost]    
            [Route("deleteAchievments")]
        public IHttpActionResult deleteAchievem(Achievement_details alist)
        {
            Boolean h = new AchevementDetailsRelated().deleteAchievements(alist);
            if(h)
            {
                response.code = 200;
                response.message = "succesfully data was deleted";
                return Content(HttpStatusCode.OK, response);
            }
            else
            {
                response.code = 100;
                response.message = "failed to delete data";
                return Content(HttpStatusCode.OK, response);
            }

        }

    
  }
}
