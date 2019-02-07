using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class AssignmentDetailsRelated
    {

        DateTime fromDate;
        String topicName;

        int count;
        public Boolean addingAssignDetails(assignment_details details)
        {
            List<assignment_details> tlist = new List<assignment_details>();

            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.assignment_details.OrderBy(a => a.assignment_from_date).ToList();
                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                    fromDate = tlist[i].assignment_from_date;
                    topicName = tlist[i].assignment_enter_topic;

                    if (details.assignment_from_date.Equals(fromDate) && details.assignment_enter_topic.Equals(topicName))
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