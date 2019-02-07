using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class SyllabusDetailsRelated
    {

        String cls, subject, unit, topic, subunit;
        int count, schoolid;
        public Boolean addingSyllabus(syllabus_details adding)
        {
            List<syllabus_details> slist = new List<syllabus_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.syllabus_details.OrderBy(a => a.syllabus_subject).ToList();
                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {
                    cls = slist[i].syllabus_class;
                    subject = slist[i].syllabus_subject;
                    unit = slist[i].syllabus_unit;
                    topic = slist[i].syllabus_topic;

                    if (adding.syllabus_class.Equals(cls) && adding.syllabus_subject.Equals(subject) && adding.syllabus_unit.Equals(unit) && adding.syllabus_topic.Equals(topic))
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


        public Boolean updateSyllabus(syllabus_details update)
        {
            List<syllabus_details> ulist = new List<syllabus_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                ulist = dc.syllabus_details.OrderBy(a => a.syllabus_class).ToList();

                int cc = ulist.Count;
                for (int i = 0; i < cc; i++)
                {
                    cls = ulist[i].syllabus_class;
                    subject = ulist[i].syllabus_subject;
                    schoolid = ulist[i].school_id;
                    if (update.syllabus_class.Equals(cls) && update.syllabus_subject.Equals(subject) && update.school_id.Equals(schoolid))
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
                    syllabus_details updatedCustomer = (from c in entities.syllabus_details
                                                        join p in entities.school_details on update.school_id equals p.school_id
                                                        where c.syllabus_class == update.syllabus_class
                                                        select c).FirstOrDefault();
                    updatedCustomer.syllabus_topic = update.syllabus_topic;
                    updatedCustomer.syllabus_subunit = update.syllabus_subunit;
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