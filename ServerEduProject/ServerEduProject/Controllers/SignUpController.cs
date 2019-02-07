using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    //[RoutePrefix("giest")]
    public class SignUpController : ApiController
    {

        EdujinniEntity entity = new EdujinniEntity();

        ResponseMessage response = new ResponseMessage();

        [HttpPost]
        [Route("guestSignUp")]
        public IHttpActionResult gustSignUp(guest_signup gsignUp)
        {
            ResponseMessage rs = new ResponseMessage();
            Boolean b = new SignUpRelated().guestSignUp(gsignUp);
            if (b)
            {
                gsignUp.insert_date = DateTime.Now;
                entity.guest_signup.Add(gsignUp);
                entity.SaveChanges();

                
                rs.code = 200;
                rs.message = "succesfully data has inserted";

                return Content(HttpStatusCode.OK, rs);
            }
            else
            {
                
                rs.code = 100;
                rs.message = "data insertion has failed";

                return Content(HttpStatusCode.OK, rs);
            }
        }


        [HttpPost]
        [Route("guestLogin")]
        public IHttpActionResult guestLogin(guest_signup gsignUp)
        {
            Boolean b = new SignUpRelated().guestLogins(gsignUp);
            ResponseMessage rs = new ResponseMessage();

            if (b)
            {
                
                rs.code = 200;
                rs.message = "succesfully loggeg in";

                return Content(HttpStatusCode.OK, rs);
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
