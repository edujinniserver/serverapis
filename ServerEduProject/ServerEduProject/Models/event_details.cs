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
    
    public partial class event_details
    {
        public int event_id { get; set; }
        public int school_id { get; set; }
        public string event_image { get; set; }
        public System.DateTime event_date { get; set; }
        public string event_name { get; set; }
        public string event_description { get; set; }
        public string insert_by { get; set; }
        public Nullable<System.DateTime> insert_date { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public Nullable<int> section_id { get; set; }
        public Nullable<int> class_id { get; set; }
    
        public virtual school_details school_details { get; set; }
        public virtual class_details class_details { get; set; }
        public virtual Section Section { get; set; }
    }
}
