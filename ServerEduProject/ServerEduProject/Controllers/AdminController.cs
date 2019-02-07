using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerEduProject.Models;
namespace ServerEduProject.Controllers
{
    public class AdminController : ApiController
    {

        public static int scl_id;
        ResponseMessage rs = new ResponseMessage();

        EdujinniEntity enty = new EdujinniEntity();

        [HttpPost]
        [Route("adminSignup")]
        public IHttpActionResult adminSignUp(school_details sdetails)
        {
            Boolean bb = new AdminSignup().addingSchool(sdetails);

            if (bb)
            {
                sdetails.insert_date = DateTime.Now;
                enty.school_details.Add(sdetails);
                enty.SaveChanges();

                rs.code = 200;
                rs.message = "succesfully data has inserted";
                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                rs.code = 100;
                rs.message = "failed to insert";
                return Content(HttpStatusCode.OK, rs);
            }
        }




        [HttpPost]
        [Route("updateAdmin")]
        public IHttpActionResult updatePassword(school_details sd)
        {
            Boolean d = new AdminSignup().updateExamSubjectsList(sd);
            if (d)
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


        int count;
        string email, password;

        [HttpPost]
        [Route("adminLogin")]
        public IHttpActionResult guestLogin(school_details gsignUp)
        {
            Boolean b = new AdminSignup().adminLogin(gsignUp);

            ResponseMessage rs = new ResponseMessage();

            if (b)
            {



                var studets_count = (from a in enty.school_details
                                 where a.password == gsignUp.password
                                 select new
                                 {
                                    a.school_id,
                                    a.admin_image,
                                    a.school_image,
                                    a.admin_full_name,
                                    a.school_name
                          });

                rs.code = 200;
                rs.message = "succesfully logged in";
                rs.Data = studets_count;

            return Content(HttpStatusCode.OK, rs);


                /* List<school_details> login = new List<school_details>();

                 using (EdujinniEntity entitu = new EdujinniEntity())
                 {
                     login = entitu.school_details.OrderBy(a => a.school_name).ToList();
                     int cc = login.Count;
                     for (int i = 0; i < cc; i++)
                     {

                         // mnumber = login[i].school_phone_no;
                         //mnumber = Convert.ToInt64(login[i].admin_mobile_no);
                         email = login[i].admin_email;
                         password = login[i].password;

                         if (gsignUp.password.Equals(password) && gsignUp.admin_email.Equals(email))
                         {                                               
                                 count = 1;
                                 scl_id = login[i].school_id;
                                 break;                        
                         }
                         else
                         {
                             count = 0;
                         }
                     }
                 }
                 if (count == 1)
                 {

                     rs.code = 200;
                     rs.schoolId = scl_id;
                     rs.message = "succesfully logged in";

                     return Content(HttpStatusCode.OK, rs);
                 }
                 else
                 {
                     rs.code = 100;

                     rs.message = "failed to logged in";

                     return Content(HttpStatusCode.OK, rs); ;
                 }

         */


            }
            else
            {

                rs.code = 100;
                rs.message = "failed to loggedin";

                return Content(HttpStatusCode.OK, rs);
            }
        }


    }
}
