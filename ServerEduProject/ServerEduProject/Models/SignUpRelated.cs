using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerEduProject.Models
{
    
    public class SignUpRelated
    {

        long mobileNumber;
        String fname, passwd;
        int count;
        public Boolean guestSignUp(guest_signup gsignUp)
        {
            List<guest_signup> g = new List<guest_signup>();

            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                g = entitu.guest_signup.OrderBy(a => a.first_name).ToList();
                int cc = g.Count;
                for (int i = 0; i < cc; i++)
                {
                    mobileNumber = g[i].mobile_no;

                    if (gsignUp.mobile_no.Equals(mobileNumber))
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



        public Boolean guestLogins(guest_signup gsignUp)
        {
            List<guest_signup> login = new List<guest_signup>();

            using (EdujinniEntity entitu = new EdujinniEntity())
            {
                login = entitu.guest_signup.OrderBy(a => a.first_name).ToList();
                int cc = login.Count;
                for (int i = 0; i < cc; i++)
                {
                    mobileNumber = login[i].mobile_no;
                    fname = login[i].first_name;
                    passwd = login[i].confirm_pswd;

                    if (gsignUp.mobile_no.Equals(mobileNumber) || gsignUp.first_name.Equals(fname))
                    {
                        if (gsignUp.confirm_pswd.Equals(passwd))
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