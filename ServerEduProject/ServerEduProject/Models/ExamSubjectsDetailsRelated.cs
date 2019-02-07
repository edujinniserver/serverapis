using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class ExamSubjectsDetailsRelated
    {
        String examClass, section, subName;
        int count, sclId;
        public Boolean addExamSubjDetails(examsubject_details esubj)
        {
            List<examsubject_details> elist = new List<examsubject_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                elist = dc.examsubject_details.OrderBy(a => a.examsubject_class).ToList();
                int cc = elist.Count;
                for (int i = 0; i < cc; i++)
                {
                    
                    subName = elist[i].examsubject_subject_name;


                    int clsId=Convert.ToInt32( elist[i].class_id);
                    int secId = Convert.ToInt32(elist[i].section_id);
                    int exmId = Convert.ToInt32(elist[i].exam_id);
                    int clssecId = Convert.ToInt32(elist[i].examclass_id);
                    sclId = elist[i].school_id;

                    if (esubj.school_id.Equals(sclId) && esubj.class_id.Equals(clsId) && esubj.section_id.Equals(secId)&& esubj.examsubject_subject_name.Equals(subName)&& esubj.examclass_id.Equals(clssecId) && esubj.exam_id.Equals(exmId))
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


        public Boolean updateExamSubjectsList(examsubject_details eupdate)
        {
            List<examsubject_details> tlist = new List<examsubject_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.examsubject_details.OrderBy(a => a.examsubject_class).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = tlist[i].examsubject_class;
                    section = tlist[i].examsubject_section;
                    subName = tlist[i].examsubject_subject_name;
                    sclId = tlist[i].school_id;
                    int examSubId = tlist[i].examsubject_id;

                    if (eupdate.school_id.Equals(sclId) && eupdate.examsubject_id.Equals(examSubId))
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
                    examsubject_details updatedCustomer = (from c in entities.examsubject_details
                                                           join p in entities.school_details on eupdate.school_id equals p.school_id
                                                           where c.school_id == eupdate.school_id
                                                           where c.examsubject_id == eupdate.examsubject_id
                                                           select c).FirstOrDefault();
                    updatedCustomer.examsubject_class = eupdate.examsubject_class;
                    updatedCustomer.examsubject_subject_type = eupdate.examsubject_subject_type;
                    updatedCustomer.examsubject_marks = eupdate.examsubject_marks;
                    updatedCustomer.examsubject_date = eupdate.examsubject_date;
                    updatedCustomer.exam_id = eupdate.exam_id;
                    updatedCustomer.examclass_id = eupdate.examclass_id;
                    updatedCustomer.examsubject_syllabus = eupdate.examsubject_syllabus;                  
                    updatedCustomer.examsubject_start_time = eupdate.examsubject_start_time;
                    updatedCustomer.examsubject_end_time = eupdate.examsubject_end_time;
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



        public Boolean deleteExams(examsubject_details edel)
        {
            List<examsubject_details> tlist = new List<examsubject_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.examsubject_details.OrderBy(a => a.examsubject_class).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examClass = tlist[i].examsubject_class;
                    section = tlist[i].examsubject_section;
                    subName = tlist[i].examsubject_subject_name;
                    sclId = tlist[i].school_id;
                    int examSubId = tlist[i].examsubject_id;

                    if (edel.school_id.Equals(sclId) && edel.examsubject_id.Equals(examSubId))
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
                    examsubject_details custom = (from c in entities.examsubject_details
                                                 where c.examsubject_id==edel.examsubject_id                                                  
                                                  where c.school_id == edel.school_id
                                                select c).FirstOrDefault();
                    entities.examsubject_details.Remove(custom);
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