using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace projectPrototypeTwo
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
            logs.checkLoginStatus();
            if (logs.loginStatus == true)
            {
                logs.isAdminUserCheck();
                if (logs.isAdminUser == true)
                {
                    btn_login.Text = "Log out";
                    btn_register.Visible = false;
                }
                else
                {
                    btn_login.Text = "Log out";
                    btn_register.Text = "Profile";
                }
            }
            else
            {
                btn_login.Text = "Log in";
                btn_register.Text = "Register";

                btn_register.Visible = true;
            }
        }

        Logins logs = new Logins();

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            logs.checkLoginStatus();
            if (logs.loginStatus == false)
            {
                login log = new login();
                log.ShowDialog();
                this.Close();
            }
            else
            {
                logs.loginStatus = false;
                btn_register.Visible = true;
                btn_register.Text = "Register";
                btn_login.Text = "log in";
                logs.newSessionADD();
            }
        }

        private void btn_customOrder_Click(object sender, EventArgs e)
        {
            customOrder co = new customOrder();
            co.ShowDialog();
        }

        private void btn_existingOrder_Click(object sender, EventArgs e)
        {
            types tEI = new types();
            tEI.Show();
            this.Hide();
        }

        private void btn_privacyPolicy_Click(object sender, EventArgs e)
        {
            termsAndconditions tac = new termsAndconditions();
            tac.ShowDialog();
        }

        private void btn_contactUs_Click(object sender, EventArgs e)
        {
            contactUs cus = new contactUs();
            cus.ShowDialog();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            logs.checkLoginStatus();
            if (logs.loginStatus == false)
            {
                register reg = new register();
                reg.ShowDialog();
            }
            else
            {
                profile prof = new profile();
                prof.Show();
            }
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            aboutA about = new aboutA();
            about.ShowDialog();
        }
    }
}
