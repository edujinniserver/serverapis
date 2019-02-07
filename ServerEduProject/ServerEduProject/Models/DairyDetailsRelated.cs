using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class DairyDetailsRelated
    {

        int count;
        String subject;
        DateTime issuedate;
        public Boolean addingDairyData(dairy_details adding)
        {
            List<dairy_details> dlist = new List<dairy_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                dlist = dc.dairy_details.OrderBy(a => a.dairy_date).ToList();
                int cc = dlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    issuedate = dlist[i].dairy_date;
                    subject = dlist[i].dairy_subject;

                    if (adding.dairy_date.Equals(issuedate) && adding.dairy_subject.Equals(subject))
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



    }
}