using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class TeacherDetails
    {
        String tEmail,ttId;
        long tMobile;
        int count;
        int  sclId,tId;
        string tid;


        public Boolean addingTeacher(teacher_details adding)
        {
            List<teacher_details> tdetails = new List<teacher_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tdetails = dc.teacher_details.OrderBy(a => a.teacher_first_name).ToList();
                int cc = tdetails.Count;
                for (int i = 0; i < cc; i++)
                {
                    tEmail = tdetails[i].teacher_email;
                    tMobile = tdetails[i].teacher_phone_no;
                    ttId = tdetails[i].teacher_teacherid;
                    if (adding.teacher_email.Equals(tEmail) && adding.teacher_phone_no.Equals(tMobile)&& adding.teacher_teacherid.Equals(ttId))
                    {
                        count = 1;
                        break;
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            if (count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }




        public Boolean updateTeacher(teacher_details tdetails)
        {
            List<teacher_details> tlist = new List<teacher_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.teacher_details.OrderBy(a => a.teacher_first_name).ToList();
                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    tid = tlist[i].teacher_teacherid;
                    tId = tlist[i].teacher_id;
                    tEmail = tlist[i].teacher_email;
                    tMobile = tlist[i].teacher_phone_no;
                    sclId = tlist[i].school_id;

                    if (tdetails.teacher_id.Equals(tId) &&tdetails.school_id.Equals(sclId))
                    {
                        count = 0;
                        break;
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }
            if(count==0)
            {
                using (EdujinniEntity entities = new EdujinniEntity())
                {
                    teacher_details updatedCustomer = (from c in entities.teacher_details
                                                     where c.school_id == tdetails.school_id
                                                     where c.teacher_id==tdetails.teacher_id
                                                     select c).FirstOrDefault();
                    updatedCustomer.teacher_first_name = tdetails.teacher_first_name;
                    updatedCustomer.teacher_last_name = tdetails.teacher_last_name;
                    updatedCustomer.teacher_qualification = tdetails.teacher_qualification;
                    updatedCustomer.teacher_subject1 = tdetails.teacher_subject1;
                    updatedCustomer.teacher_subject2 = tdetails.teacher_subject2;
                    updatedCustomer.teacher_area = tdetails.teacher_area;
                    updatedCustomer.teacher_city = tdetails.teacher_city;
                    updatedCustomer.teacher_date_of_joining = tdetails.teacher_date_of_joining;
                    updatedCustomer.teacher_department = tdetails.teacher_department;
                    updatedCustomer.teacher_dob = tdetails.teacher_dob;
                    updatedCustomer.teacher_email = tdetails.teacher_email;
                    updatedCustomer.teacher_image = tdetails.teacher_image;
                    updatedCustomer.teacher_phone_no = tdetails.teacher_phone_no;
                    updatedCustomer.teacher_pincode = tdetails.teacher_pincode;
                    updatedCustomer.teacher_qualification = tdetails.teacher_qualification;
                    updatedCustomer.teacher_state = tdetails.teacher_state;
                    updatedCustomer.teacher_teacherid = tdetails.teacher_teacherid;
                    updatedCustomer.teacher_street = tdetails.teacher_street;
                    updatedCustomer.teacher_street1 = tdetails.teacher_street1;
                    updatedCustomer.teacher_status = tdetails.teacher_status;
                    updatedCustomer.class_id = tdetails.class_id;
                    updatedCustomer.update_date = DateTime.Now;
                    entities.SaveChanges();
                }
                return true;
            }
            else
            {
                return false;
            }


        }



        public Boolean deleteTeacher(teacher_details tdata)
        {
            List<teacher_details> tlist = new List<teacher_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.teacher_details.OrderBy(a => a.teacher_first_name).ToList();
                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    tEmail = tlist[i].teacher_email;
                    tMobile = tlist[i].teacher_phone_no;
                    int scl_id = tlist[i].school_id;
                    tId = tlist[i].teacher_id;

                    if (tdata.school_id.Equals(scl_id)&&tdata.teacher_id.Equals(tId))
                    {
                        count = 0;
                        break;
                    }
                    else
                    {
                        count = 1;
                    }
                }
            }
            if (count == 0)
            {

                using (EdujinniEntity entities = new EdujinniEntity())
                {
                    teacher_details updatedCustomer = (from c in entities.teacher_details
                                                       where c.school_id == tdata.school_id
                                                       where c.teacher_id == tdata.teacher_id
                                                       select c).FirstOrDefault();                    
                    updatedCustomer.update_date = DateTime.Now;
                    updatedCustomer.teacher_status = "In-Active";
                    entities.SaveChanges();
                }

                return true;
            }
            else
            {
                return false;
            }
        }







    }
}