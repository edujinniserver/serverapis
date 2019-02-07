using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class ExamDetailsRelated
    {

        String examClass, examSection, examType;
        int count, sclId,exmId;
        public Boolean addingExamClassDetails(exam_details exmclass)
        {

            List<exam_details> exlist = new List<exam_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                exlist = dc.exam_details.OrderBy(a => a.exam_type).ToList();
                int cc = exlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = exlist[i].exam_type;                    
                    sclId = exlist[i].school_id;

                    if (exmclass.exam_type.Equals(examClass) && exmclass.school_id.Equals(sclId))
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



        public Boolean updateExamClassDetails(exam_details edetails)
        {
            List<exam_details> tlist = new List<exam_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.exam_details.OrderBy(a => a.exam_type).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = tlist[i].exam_type;                    
                    sclId = tlist[i].school_id;
                    exmId = tlist[i].exam_id;
                    if (edetails.school_id.Equals(sclId) && edetails.exam_id.Equals(exmId))
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
                    exam_details updatedCustomer = (from c in entities.exam_details
                                                         join p in entities.school_details on edetails.school_id equals p.school_id
                                                         where c.exam_id == edetails.exam_id
                                                         where c.school_id == edetails.school_id
                                                    select c).FirstOrDefault();
                    updatedCustomer.exam_start_date = edetails.exam_start_date;
                    updatedCustomer.exam_end_date = edetails.exam_end_date;
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




        public Boolean deleteExam(exam_details elist)
        {
            List<exam_details> tlist = new List<exam_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.exam_details.OrderBy(a => a.exam_type).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = tlist[i].exam_type;
                    sclId = tlist[i].school_id;
                    exmId = tlist[i].exam_id;
                    if (elist.school_id.Equals(sclId) && elist.exam_id.Equals(exmId))
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
                    exam_details custom = (from c in entities.exam_details
                                                  where c.exam_id == elist.exam_id
                                           where c.school_id == elist.school_id
                                                  select c).FirstOrDefault();
                    entities.exam_details.Remove(custom);
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