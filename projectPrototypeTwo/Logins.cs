using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectPrototypeTwo
{
    class Logins
    {
        public bool loginStatus = false;
        public string loggedUserName ;

        public void checkLoginStatus()
        {
            if (loginStatus == false)
            {
                login log = new login();
                log.ShowDialog();
            }
        }

        public void saveUsername(string un)
        {
            loggedUserName = un;
        }

        public void updateLoginStatus(bool value)
        {
            loginStatus = value;
        }

        public void setPassedValues(string username, bool status)
        {
            loggedUserName = username;
            loginStatus = status;
        }
    }
}
