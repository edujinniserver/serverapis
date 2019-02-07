using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class SubjectDetailsrelated
    {
        String subjType, subjName;
        int sid, cid, tid;
        int count;
        public Boolean addSubjectDetails(subject_details adding)
        {

            List<subject_details> slist = new List<subject_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.subject_details.OrderBy(a => a.subject_type).ToList();
                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {
                    subjType = slist[i].subject_type;
                    subjName = slist[i].subject_name;

                    if (adding.subject_type.Equals(subjType) && adding.subject_name.Equals(subjName))
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


        public Boolean updatingSubjects(subject_details updating)
        {
            List<subject_details> slist = new List<subject_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.subject_details.OrderBy(a => a.subject_type).ToList();

                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {                    
                    sid = slist[i].school_id;                   
                    int subId = slist[i].subject_id;
                    if (updating.subject_id.Equals(subId) && updating.school_id.Equals(sid))
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
                    subject_details updatedCustomer = (from c in entities.subject_details
                                                       join p in entities.school_details on updating.school_id equals p.school_id
                                                       where c.subject_id == updating.subject_id
                                                       where c.school_id == updating.school_id
                                                       select c).FirstOrDefault();
                    updatedCustomer.subject_name = updating.subject_name;
                    updatedCustomer.subject_type = updating.subject_type;
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



        public Boolean deleteSubjects(subject_details slists)
        {
            List<subject_details> slist = new List<subject_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                slist = dc.subject_details.OrderBy(a => a.subject_type).ToList();

                int cc = slist.Count;
                for (int i = 0; i < cc; i++)
                {
                    sid = slist[i].school_id;
                    int subId = slist[i].subject_id;
                    if (slists.subject_id.Equals(subId) && slists.school_id.Equals(sid))
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
                    subject_details updatedCustomer = (from c in entities.subject_details
                                                       //join p in entities.school_details on updating.school_id equals p.school_id
                                                       where c.subject_id == slists.subject_id
                                                       where c.school_id == slists.school_id
                                                       select c).FirstOrDefault();
                    entities.subject_details.Remove(updatedCustomer);
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