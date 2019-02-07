using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class AchevementDetailsRelated
    {

        String mnumber;
        int count, studentId;
        int sclId;


        public Boolean addingAchievemnts(Achievement_details adding)
        {
            List<Achievement_details> list = new List<Achievement_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                list = dc.Achievement_details.OrderBy(a => a.achievement_type).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    mnumber = list[i].achievement_type;
                    studentId = list[i].student_id;
                    sclId = list[i].school_id;

                    if (adding.achievement_type.Equals(mnumber) && adding.student_id.Equals(studentId)&& adding.school_id.Equals(sclId))
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



        public Boolean updateAchievements(Achievement_details adetails)
        {
            List<Achievement_details> list = new List<Achievement_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                list = dc.Achievement_details.OrderBy(a => a.achievement_type).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                    int achId = list[i].achievement_id;
                    int sclId = list[i].school_id;
                    //mnumber = list[i].achievement_type;
                    //studentId = list[i].student_id;

                    if (adetails.school_id.Equals(sclId) && adetails.achievement_id.Equals(achId))
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

            if (count == 1)
            {
                using (EdujinniEntity entities = new EdujinniEntity())
                {
                    Achievement_details updatedCustomer = (from c in entities.Achievement_details
                                                       where c.achievement_id == adetails.achievement_id
                                                       where c.school_id == adetails.school_id
                                                           select c).FirstOrDefault();
                    updatedCustomer.class_id = adetails.class_id;
                    updatedCustomer.section_id = adetails.section_id;
                    updatedCustomer.student_id = adetails.student_id;
                    updatedCustomer.achievement_student_name = adetails.achievement_student_name;
                    updatedCustomer.achievement_description = adetails.achievement_description;
                    updatedCustomer.achievement_date=adetails.achievement_date;
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




        public Boolean deleteAchievements(Achievement_details adata)
        {
            List<Achievement_details> list = new List<Achievement_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                list = dc.Achievement_details.OrderBy(a => a.achievement_type).ToList();
                int cc = list.Count;
                for (int i = 0; i < cc; i++)
                {
                   int aId = list[i].achievement_id;
                    sclId = list[i].school_id;
                    if (adata.achievement_id.Equals(aId) && adata.school_id.Equals(sclId))
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
            if (count == 1)
            {

                using (EdujinniEntity entities = new EdujinniEntity())
                {
                    Achievement_details custom = (from c in entities.Achievement_details
                                              where c.achievement_id == adata.achievement_id
                                              where c.school_id == adata.school_id                                                  
                                                  select c).FirstOrDefault();
                    entities.Achievement_details.Remove(custom);
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