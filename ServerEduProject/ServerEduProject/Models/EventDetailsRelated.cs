using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class EventDetailsRelated
    {

        String eventName;
        int count,sclId,eventId;
        public Boolean addingEventsDetails(event_details events)
        {
            List<event_details> elist = new List<event_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                elist = dc.event_details.OrderBy(a => a.event_name).ToList();
                int cc = elist.Count;

                for (int i = 0; i < cc; i++)
                {
                    eventName = elist[i].event_name;

                    if (events.event_name.Equals(eventName))
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



        public Boolean UpdateEvents(event_details events)
        {
            List<event_details> evList = new List<event_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                evList = dc.event_details.OrderBy(a => a.event_name).ToList();

                int cc = evList.Count;
                for (int i = 0; i < cc; i++)
                {
                    eventName = evList[i].event_name;
                    sclId = evList[i].school_id;
                   int evtId = evList[i].event_id;
                    if (events.school_id.Equals(sclId) && events.event_id.Equals(evtId))
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
                    event_details updatedCustomer = (from c in entities.event_details
                                                     where c.school_id == events.school_id
                                                     where c.event_id == events.event_id
                                                     select c).FirstOrDefault();
                    updatedCustomer.event_description = events.event_description;
                    updatedCustomer.event_image = events.event_image;
                    updatedCustomer.event_date = events.event_date;                    
                    updatedCustomer.event_name = events.event_name;
                    updatedCustomer.section_id = events.section_id;
                    updatedCustomer.class_id = events.class_id;
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



        public Boolean deleteSection(event_details secn)
        {
            List<event_details> secList = new List<event_details>();
            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                secList = entitu.event_details.OrderBy(a => a.event_date).ToList();
                for (int m = 0; m < secList.Count; m++)
                {
                    eventName = secList[m].event_name;
                    eventId = secList[m].event_id;
                    sclId = secList[m].school_id;
                    if (secn.school_id.Equals(sclId) && secn.event_id.Equals(eventId))
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
                    event_details custom = (from c in entities.event_details
                                            where c.school_id == secn.school_id
                                            where c.event_id == secn.event_id
                                            select c).FirstOrDefault();
                    entities.event_details.Remove(custom);
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