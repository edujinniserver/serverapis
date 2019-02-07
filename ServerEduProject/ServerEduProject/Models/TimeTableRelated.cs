using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class TimeTableRelated
    {
        String day;
        int sclId;
        int count, subid, clsid, teacid,tmtId;

        public Boolean addingTimeTable(timetable_details adding)
        {
            List<timetable_details> tlist = new List<timetable_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.timetable_details.OrderBy(a => a.timetable_day).ToList();
                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    day = tlist[i].timetable_day;
                    sclId = tlist[i].school_id;
                    if (adding.timetable_day.Equals(day) && adding.school_id.Equals(sclId))
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



        public Boolean updateTimeTable(timetable_details update)
        {
            List<timetable_details> tlist = new List<timetable_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.timetable_details.OrderBy(a => a.timetable_day).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    day = tlist[i].timetable_day;
                    sclId = tlist[i].school_id;
                    subid = tlist[i].subject_id;
                    clsid = tlist[i].class_id;
                    teacid = tlist[i].teacher_id;
                    int tmtId = tlist[i].timetable_id;
                    if (update.school_id.Equals(sclId) && update.timetable_id.Equals(tmtId))
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
                    timetable_details updatedCustomer = (from c in entities.timetable_details
                                                         join p in entities.school_details on update.school_id equals p.school_id
                                                         where c.school_id == update.school_id
                                                         where c.timetable_id ==update.timetable_id
                                                         select c).FirstOrDefault();
                    updatedCustomer.teacher_id = update.teacher_id;
                    updatedCustomer.timetable_start_time = update.timetable_start_time;
                    updatedCustomer.timetable_end_time = update.timetable_end_time;
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

        public Boolean deleteTimeTbles(timetable_details ttd)
        {
            List<timetable_details> tlist = new List<timetable_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.timetable_details.OrderBy(a => a.timetable_day).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    day = tlist[i].timetable_day;
                    sclId = tlist[i].school_id;
                    tmtId = tlist[i].timetable_id;
                    if (ttd.school_id.Equals(sclId) && ttd.timetable_id.Equals(tmtId))
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
                    timetable_details updatedCustomer = (from c in entities.timetable_details
                                                         join p in entities.school_details on ttd.school_id equals p.school_id
                                                         where c.school_id == ttd.school_id
                                                         where c.timetable_id == ttd.timetable_id
                                                         select c).FirstOrDefault();
                    entities.timetable_details.Remove(updatedCustomer);
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