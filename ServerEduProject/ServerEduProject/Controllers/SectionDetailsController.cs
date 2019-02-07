using ServerEduProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServerEduProject.Controllers
{
    public class SectionDetailsController : ApiController
    {

        EdujinniEntity entities = new EdujinniEntity();

        ResponseMessage rs = new ResponseMessage();

        [HttpPost]
        [Route("addSection")]
        public IHttpActionResult AddingSection(Section sectn)
        {

            Boolean b = new SectionDetailsRelated().AddSection(sectn);

            if (b)
            {
                sectn.insert_date = DateTime.Now;
                entities.Sections.Add(sectn);
                entities.SaveChanges();

                
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
        [Route("deleteSection")]
        public IHttpActionResult deleteSection(Section ss)
        {
            Boolean b = new SectionDetailsRelated().deleteSection(ss);
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
        [Route("sectionList")]
        public ResponseMessage subjectsList(Section slist)
        {
            var entryPoint = (from ep in entities.Sections
                              join e in entities.school_details on slist.school_id equals e.school_id                              
                              where ep.school_id == slist.school_id                              
                              select new
                              {
                                  ep.section_name,
                                  ep.section_id,
                                  ep.school_id
                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;

        }






        [HttpPost]
        [Route("single/sectionList")]
        public ResponseMessage subjectList(Section sec)
        {
            var entryPoint = (from ep in entities.Sections
                              //join e in entities.school_details on ep.school_id equals e.school_id                              
                              where ep.school_id== sec.school_id
                              select new
                              {
                                  ep.section_name,                                  
                              });
            rs.Data = entryPoint;
            rs.code = 200;
            rs.message = "Data success";
            return rs;

        }



        [HttpPost]
        [Route("updateSection")]
        public IHttpActionResult updateSection(Section secti)
        {
            Boolean vv = new SectionDetailsRelated().updateSection(secti);
            if(vv)
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





    }
}
