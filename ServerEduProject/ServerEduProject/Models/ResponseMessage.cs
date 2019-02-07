using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class ResponseMessage
    {
        public int code { get; set; }

        public String message { get; set; }

        public Object Data { get; set; }

       // public int schoolId { get; set; }

    }
}