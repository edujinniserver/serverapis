using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class ExamClassDetails
    {
        String examClass, examSection, examType;
        int count, sclId;
        public Boolean addingExamClassDetails(examclass_details exmclass)
        {

            List<examclass_details> exlist = new List<examclass_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                exlist = dc.examclass_details.OrderBy(a => a.examclass_class).ToList();
                int cc = exlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = exlist[i].examclass_class;
                    examSection = exlist[i].examclass_section;
                    examType = exlist[i].examclass_exam_type;
                    sclId = exlist[i].school_id;

                    if (exmclass.examclass_class.Equals(examClass) && exmclass.school_id.Equals(sclId) && exmclass.examclass_section.Equals(examSection) && exmclass.examclass_exam_type.Equals(examType))
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



        public Boolean updateExamClassDetails(examclass_details edetails)
        {
            List<examclass_details> tlist = new List<examclass_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.examclass_details.OrderBy(a => a.examclass_class).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = tlist[i].examclass_class;
                    examSection = tlist[i].examclass_section;
                    sclId = tlist[i].school_id;
                    int examclass_id = tlist[i].examclass_id;
                    if (edetails.school_id.Equals(sclId) && edetails.examclass_id.Equals(examclass_id))
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
                    examclass_details updatedCustomer = (from c in entities.examclass_details
                                                         join p in entities.school_details on edetails.school_id equals p.school_id
                                                         where c.school_id == edetails.school_id
                                                         where c.examclass_id == edetails.examclass_id
                                                         select c).FirstOrDefault();
                    updatedCustomer.examclass_exam_type = edetails.examclass_exam_type;
                    updatedCustomer.examclass_start_date = edetails.examclass_start_date;
                    updatedCustomer.examclass_end_date = edetails.examclass_end_date;
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







        public Boolean deleteClass(examclass_details edetails)
        {
            List<examclass_details> tlist = new List<examclass_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.examclass_details.OrderBy(a => a.examclass_class).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = tlist[i].examclass_class;
                    examSection = tlist[i].examclass_section;
                    sclId = tlist[i].school_id;
                    int exmClsId = tlist[i].examclass_id;
                    if (edetails.school_id.Equals(sclId) && edetails.examclass_id.Equals(exmClsId))
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
                    examclass_details custom = (from c in entities.examclass_details                                           
                                           where c.examclass_id==edetails.examclass_id
                                                where c.school_id == edetails.school_id
                                           select c).FirstOrDefault();
                    entities.examclass_details.Remove(custom);
                    entities.SaveChanges();
                }
                return true;
            }else
            {
                return false;
            }




        }







    }
}