//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServerEduProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class guest_signup
    {
        public int guest_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long mobile_no { get; set; }
        public System.DateTime dateof_birth { get; set; }
        public string create_pswd { get; set; }
        public string confirm_pswd { get; set; }
        public string gender { get; set; }
        public string insert_by { get; set; }
        public Nullable<System.DateTime> insert_date { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
    }
}
