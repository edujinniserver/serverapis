using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class AddingClassDetails
    {

        String className, classSection;
        int count,sclId;
        public Boolean addingClassDetails(class_details classDetails)
        {
            List<class_details> cdetails = new List<class_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                cdetails = dc.class_details.OrderBy(a => a.class_name).ToList();
                int cc = cdetails.Count;
                for (int i = 0; i < cc; i++)
                {
                    className = cdetails[i].class_name;
                    classSection = cdetails[i].class_section_name;
                    sclId = Convert.ToInt32(cdetails[i].school_id);

                    if (classDetails.class_name.Equals(className) && classDetails.class_section_name.Equals(classSection)&&classDetails.school_id.Equals(sclId))
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

        public Boolean deletingClassDetails(class_details deleting)
        {
            List<class_details> secList = new List<class_details>();
            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                secList = entitu.class_details.OrderBy(a => a.class_name).ToList();
                for (int m = 0; m < secList.Count; m++)
                {
                    className = secList[m].class_name;
                    sclId = Convert.ToInt32(secList[m].school_id);
                    //classSection = secList[m].class_section_name;
                    int clsId = secList[m].class_id;

                    if (deleting.class_id.Equals(clsId) && deleting.school_id.Equals(sclId))
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
                    class_details custom = (from c in entities.class_details
                                            where c.class_id == deleting.class_id
                                            where c.school_id==deleting.school_id
                                            select c).FirstOrDefault();
                    entities.class_details.Remove(custom);
                    entities.SaveChanges();
                }

                return true;
            }
            else
            {
                return false;
            }
        }







        public Boolean updateClasses(class_details cdeta)
        {
            List<class_details> secList = new List<class_details>();
            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                secList = entitu.class_details.OrderBy(a => a.class_name).ToList();
                for (int m = 0; m < secList.Count; m++)
                {
                    className = secList[m].class_name;
                    sclId = Convert.ToInt32(secList[m].school_id);
                    //classSection = secList[m].class_section_name;
                    int clsId = secList[m].class_id;

                    if (cdeta.class_id.Equals(clsId) && cdeta.school_id.Equals(sclId))
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
                    class_details custom = (from c in entities.class_details
                                            where c.class_id == cdeta.class_id
                                            where c.school_id == cdeta.school_id
                                            select c).FirstOrDefault();
                    custom.class_name = cdeta.class_name;
                    custom.class_section_name = cdeta.class_section_name;
                    custom.section_id = cdeta.section_id;
                    custom.teacher_id = cdeta.teacher_id;              
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