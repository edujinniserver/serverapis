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
    
    public partial class leaverequest
    {
        public int leaverequest_id { get; set; }
        public System.DateTime leaverequest_from_date { get; set; }
        public System.DateTime leaverequest_to_date { get; set; }
        public string leaverequest_description { get; set; }
        public string leaverequest_requested_by { get; set; }
        public string leaverequest_status { get; set; }
        public string leaverequest_aproved_by { get; set; }
        public string insert_by { get; set; }
        public Nullable<System.DateTime> insert_date { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public int school_id { get; set; }
    
        public virtual school_details school_details { get; set; }
    }
}