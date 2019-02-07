using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class LeaveRequestRelated
    {
        DateTime d1;
        int count;
        public Boolean addLeaveRequest(leaverequest leave)
        {
            List<leaverequest> ll = new List<leaverequest>();
            using (EdujinniEntity enty = new EdujinniEntity())
            {
                ll = enty.leaverequests.OrderBy(a => a.insert_date).ToList();
                for (int s = 0; s < ll.Count; s++)
                {
                    d1 = ll[s].leaverequest_from_date;
                    if (d1 == leave.leaverequest_from_date)
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