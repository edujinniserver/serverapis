using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class ExamResultsRelated
    {
        int count, examId, studentId;
        String subject;

        public Boolean addingExamResults(exam_results eresults)
        {
            List<exam_results> erlist = new List<exam_results>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                erlist = dc.exam_results.OrderBy(a => a.exam_id).ToList();
                int cc = erlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examId = erlist[i].exam_id;
                    studentId = erlist[i].student_id;
                    subject = erlist[i].examresult_subjects;
                    if (eresults.exam_id.Equals(examId) && eresults.student_id.Equals(studentId) && eresults.examresult_subjects.Equals(subject))
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


        public Boolean updateExamResults(exam_results update)
        {
            List<exam_results> tlist = new List<exam_results>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.exam_results.OrderBy(a => a.examresult_subjects).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    examId = tlist[i].exam_id;
                    studentId = tlist[i].student_id;
                    subject = tlist[i].examresult_subjects;

                    if (update.exam_id.Equals(examId) && update.student_id.Equals(studentId) && update.examresult_subjects.Equals(subject))
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
                    exam_results updatedCustomer = (from c in entities.exam_results
                                                    join p in entities.exam_details on update.exam_id equals p.exam_id
                                                    where c.teacher_id == update.teacher_id
                                                    where c.exam_id == update.exam_id
                                                    where c.student_id == update.student_id
                                                    select c).FirstOrDefault();
                    updatedCustomer.examresult_marks = update.examresult_marks;
                    updatedCustomer.examresult_total_marks = update.examresult_total_marks;
                    updatedCustomer.examresult_subjects = update.examresult_subjects;
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