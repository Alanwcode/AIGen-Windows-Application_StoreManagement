using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projectPrototypeTwo
{
    class Logins
    {
        public bool loginStatus = false, isAdminUser = false;
        public string loggedUserName ;
        string fileName = "sessions.bat";

        public void newSessionADD()
        {
            File.WriteAllText(fileName, "New");
        }

        public void userLogUpdate(string value)
        {
            File.WriteAllText(fileName, value);
        }

        public void isAdminUserCheck()
        {
            readLogData();
            if (loggedUserName == "adminA" || loggedUserName == "adminU" || loggedUserName == "adminR" || loggedUserName == "adminH")
            {
                isAdminUser = true;
            }
            else
            {
                isAdminUser = false;
            }
        }

        public void readLogData()
        {
            loggedUserName =  File.ReadAllText(fileName);
        }

        public void checkLoginStatus()
        {
            readLogData();
            if (loggedUserName == "New")
            {
                loginStatus = false;
            }
            else
            {
                loginStatus = true;
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
