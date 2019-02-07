using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class StudentDetailsRelated
    {

        String studentSection, stdntRollnum;
        int count, sclId, studentId;
        public Boolean addingStudentDetails(student_details sdetails)
        {
            List<student_details> slist = new List<student_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.student_details.OrderBy(a => a.student_first_name).ToList();
                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {
                    studentSection = slist[i].student_section;
                    stdntRollnum = slist[i].student_roll_no;

                    sclId = slist[i].school_id;

                    if (sdetails.student_section.Equals(studentSection) && sdetails.school_id.Equals(sclId) && sdetails.student_roll_no.Equals(stdntRollnum))
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


        public Boolean updateStudentsList(student_details update)
        {
            List<student_details> slist = new List<student_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.student_details.OrderBy(a => a.student_first_name).ToList();

                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {
                    studentSection = slist[i].student_section;
                    stdntRollnum = slist[i].student_roll_no;

                    studentId = slist[i].student_id;
                    sclId = slist[i].school_id;

                    if (update.student_id.Equals(studentId) && update.school_id.Equals(sclId))
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
                    student_details updatedCustomer = (from c in entities.student_details
                                                       join p in entities.school_details on update.school_id equals p.school_id
                                                       where c.student_id == update.student_id
                                                       where c.school_id == update.school_id
                                                       select c).FirstOrDefault();

                    updatedCustomer.student_image = update.student_image;
                    updatedCustomer.class_id = update.class_id;
                    updatedCustomer.student_last_name = update.student_last_name;
                    updatedCustomer.student_first_name = update.student_first_name;
                    updatedCustomer.student_roll_no = update.student_roll_no;
                    updatedCustomer.student_chiled_no = update.student_chiled_no;
                    updatedCustomer.student_dob = update.student_dob;
                    updatedCustomer.student_gender = update.student_gender;
                    updatedCustomer.student_father_mobile_no = update.student_father_mobile_no;
                    updatedCustomer.student_father_name = update.student_father_name;
                    updatedCustomer.student_father_occupation = update.student_father_occupation;
                    updatedCustomer.student_mother_mobile_no = update.student_mother_mobile_no;
                    updatedCustomer.student_mother_name = update.student_mother_name;
                    updatedCustomer.student_mother_occupation = update.student_mother_occupation;
                    updatedCustomer.student_no_of_siblings = update.student_no_of_siblings;
                    updatedCustomer.student_flat_no = update.student_flat_no;
                    updatedCustomer.student_buliding_name = update.student_buliding_name;
                    updatedCustomer.student_street = update.student_street;
                    updatedCustomer.student_street1 = update.student_street1;
                    updatedCustomer.student_state = update.student_state;
                    updatedCustomer.student_city = update.student_city;
                    updatedCustomer.student_pincode = update.student_pincode;
                    updatedCustomer.student_admission_date = update.student_admission_date;
                    updatedCustomer.student_area = update.student_area;
                    updatedCustomer.student_password = update.student_password;
                    updatedCustomer.parent_password = update.parent_password;

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


        public Boolean deleteStudent(student_details sdel)
        {
            List<student_details> slist = new List<student_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.student_details.OrderBy(a => a.student_first_name).ToList();

                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {
                    studentSection = slist[i].student_section;
                    stdntRollnum = slist[i].student_roll_no;

                    sclId = slist[i].school_id;
                    studentId = slist[i].student_id;
                    if (sdel.student_id.Equals(studentId) && sdel.school_id.Equals(sclId))
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
                    student_details customer = (from c in entities.student_details
                                                where c.school_id == sdel.school_id
                                                where c.student_id == sdel.student_id
                                                select c).FirstOrDefault();
                    customer.Student_status = "In-Active";
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