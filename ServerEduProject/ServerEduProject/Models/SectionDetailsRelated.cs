using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class SectionDetailsRelated
    {

        String secName;
        int count;
        int scl_id;
        public Boolean AddSection(Section sec)
        {
            List<Section> secList = new List<Section>();
            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                secList = entitu.Sections.OrderBy(a => a.section_name).ToList();
                for (int m = 0; m < secList.Count; m++)
                {
                    secName = secList[m].section_name;
                    if (sec.section_name.Equals(secName))
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

        public Boolean deleteSection(Section secn)
        {
            List<Section> secList = new List<Section>();
            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                secList = entitu.Sections.OrderBy(a => a.section_name).ToList();
                for (int m = 0; m < secList.Count; m++)
                {
                    //secName = secList[m].section_name;
                    int secId = secList[m].section_id;
                    scl_id = Convert.ToInt32( secList[m].school_id);
                    if (secn.section_id.Equals(secId) && secn.school_id.Equals(scl_id))
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
                    Section customer = (from c in entities.Sections
                                        where c.section_name == secn.section_name
                                        select c).FirstOrDefault();
                    entities.Sections.Remove(customer);
                    entities.SaveChanges();
                }

                return true;
            }
            else
            {
                return false;
            }
        }



        public Boolean updateSection(Section sec)
        {
            List<Section> secList = new List<Section>();
            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                secList = entitu.Sections.OrderBy(a => a.section_name).ToList();
                for (int m = 0; m < secList.Count; m++)
                {
                    secName = secList[m].section_name;
                    scl_id = Convert.ToInt32(secList[m].school_id);
                   int secId = secList[m].section_id;

                    if (sec.section_id.Equals(secId) && sec.school_id.Equals(scl_id))
                    {
                        count = 0;
                        break;
                    }
                    else
                    {
                        count = 1;
                    }
                }

            }if(count==0)
            {
                using (EdujinniEntity entities = new EdujinniEntity())
                {
                    Section customer = (from c in entities.Sections
                                        where c.section_id == sec.section_id
                                        where c.school_id== sec.school_id
                                        select c).FirstOrDefault();
                    customer.section_name = sec.section_name;
                    customer.update_date = DateTime.Now;
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