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
    
    public partial class examsubject_details
    {
        public int examsubject_id { get; set; }
        public string examsubject_class { get; set; }
        public string examsubject_section { get; set; }
        public string examsubject_subject_name { get; set; }
        public string examsubject_subject_type { get; set; }
        public string examsubject_marks { get; set; }
        public System.DateTime examsubject_date { get; set; }
        public System.TimeSpan examsubject_start_time { get; set; }
        public System.TimeSpan examsubject_end_time { get; set; }
        public string insert_by { get; set; }
        public Nullable<System.DateTime> insert_date { get; set; }
        public string update_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public int school_id { get; set; }
        public Nullable<int> section_id { get; set; }
        public Nullable<int> class_id { get; set; }
        public Nullable<int> exam_id { get; set; }
        public Nullable<int> examclass_id { get; set; }
        public string examsubject_syllabus { get; set; }
    
        public virtual school_details school_details { get; set; }
        public virtual class_details class_details { get; set; }
        public virtual exam_details exam_details { get; set; }
        public virtual examclass_details examclass_details { get; set; }
        public virtual Section Section { get; set; }
    }
}
