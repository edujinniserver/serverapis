using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class AttendenceDetails
    {

        int count, classId, sclId, studentId;
        String attenSection, rollnumber;

        public Boolean addingAteendance(attendence_details adding)
        {
            List<attendence_details> alist = new List<attendence_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                alist = dc.attendence_details.OrderBy(a => a.attendence_roll_no).ToList();
                for (int i = 0; i < alist.Count; i++)
                {
                    classId = alist[i].class_id;
                    sclId = alist[i].school_id;
                    studentId = alist[i].student_id;
                    attenSection = alist[i].attendence_section;
                    rollnumber = alist[i].attendence_roll_no;

                    if (adding.class_id.Equals(classId) && adding.school_id.Equals(sclId) && adding.student_id.Equals(studentId) && adding.attendence_section.Equals(attenSection) && adding.attendence_roll_no.Equals(rollnumber))
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



       public Boolean updateAttendence(attendence_details update)
        {
            List<attendence_details> alist = new List<attendence_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                alist = dc.attendence_details.OrderBy(a => a.attendence_roll_no).ToList();
                for (int i = 0; i < alist.Count; i++)
                {
                    classId = alist[i].class_id;
                    sclId = alist[i].school_id;
                    studentId = alist[i].student_id;
                    attenSection = alist[i].attendence_section;
                    rollnumber = alist[i].attendence_roll_no;

                    if (update.class_id.Equals(classId) && update.school_id.Equals(sclId) && update.student_id.Equals(studentId) && update.attendence_section.Equals(attenSection) && update.attendence_roll_no.Equals(rollnumber))
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
                    attendence_details updatedCustomer = (from c in entities.attendence_details
                                                          join p in entities.school_details on update.school_id equals p.school_id
                                                          where c.class_id == update.class_id
                                                          where c.school_id == update.school_id
                                                          where c.student_id == update.student_id
                                                          where c.attendence_roll_no == update.attendence_roll_no
                                                          select c).FirstOrDefault();
                    updatedCustomer.attendence_status = update.attendence_status;
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




    }
}