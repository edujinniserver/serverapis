using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    public class AdminSignup
    {
        int count;
        long mnumber;
        string email, password;

        public static Int64 scl_id;
        public Boolean addingSchool(school_details sdetails)
        {
            List<school_details> cdetails = new List<school_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                cdetails = dc.school_details.OrderBy(a => a.school_name).ToList();
                int cc = cdetails.Count;
                for (int i = 0; i < cc; i++)
                {
                    mnumber =Convert.ToInt64(cdetails[i].admin_mobile_no);
                    email = cdetails[i].admin_email;

                    if (sdetails.admin_mobile_no.Equals(mnumber) && sdetails.admin_email.Equals(email))
                    {

//                        scl_id = cdetails[i].school_id;
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

        public Boolean updateExamSubjectsList(school_details eupdate)
        {
            List<school_details> tlist = new List<school_details>();
            using (EdujinniEntity dc = new EdujinniEntity())
            {
                tlist = dc.school_details.OrderBy(a => a.school_name).ToList();

                int cc = tlist.Count;
                for (int i = 0; i < cc; i++)
                {
                     mnumber = Convert.ToInt64(tlist[i].admin_mobile_no);
                    email = tlist[i].admin_email;
                   // mnumber = tlist[i].school_phone_no;

                    if (eupdate.admin_mobile_no.Equals(mnumber))
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
                    school_details updatedCustomer = (from c in entities.school_details
                                                          //join p in entities.school_details on eupdate.school_id equals p.school_id
                                                      where c.admin_mobile_no == eupdate.admin_mobile_no
                                                      select c).FirstOrDefault();
                    updatedCustomer.password = eupdate.password;
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



        public Boolean adminLogin(school_details sdetails)
        {

            List<school_details> login = new List<school_details>();

            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                login = entitu.school_details.OrderBy(a => a.school_name).ToList();
                int cc = login.Count;
                for (int i = 0; i < cc; i++)
                {

                   // mnumber = login[i].school_phone_no;
                    mnumber = Convert.ToInt64(login[i].admin_mobile_no);
                    email = login[i].admin_email;
                    password = login[i].password;

                    if (sdetails.admin_mobile_no.Equals(mnumber) ||sdetails.admin_email.Equals(email))
                    {
                        if (sdetails.password.Equals(password))
                        {
                            count = 1;
                            break;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            if (count == 1)
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