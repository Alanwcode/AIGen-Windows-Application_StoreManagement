﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projectPrototypeTwo
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            txt_password.PasswordChar = '*';
            txt_password.MaxLength = 10;
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            register reg = new register();
            this.Close();
            reg.Show();
        }

        private void btn_privacyPolicy_Click(object sender, EventArgs e)
        {
            termsAndconditions tac = new termsAndconditions();
            tac.ShowDialog();
        }

        Logins logs = new Logins();

        private void btn_login_Click(object sender, EventArgs e)
        {
            lbl_val_invalid.Visible = false;

            try
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("select count(*) from adminLogin where username = '" + txt_username.Text + "' and passUser = '" + txt_password.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    logs.userLogUpdate(txt_username.Text);
                    adminDashboardHome adD = new adminDashboardHome();
                    adD.Show();
                    this.Close();
                }
                else
                {
                    SqlDataAdapter daUL = new SqlDataAdapter("select count(*) from customerLogin where username = '" + txt_username.Text + "' and cusPassword = '" + txt_password.Text + "'", con);
                    DataTable dtUL = new DataTable();
                    daUL.Fill(dtUL);

                    if (dtUL.Rows[0][0].ToString() == "1")
                    {
                        Logins lg = new Logins();
                        logs.userLogUpdate(txt_username.Text);
                        lg.saveUsername(txt_username.Text);
                        lg.updateLoginStatus(true);
                        this.Close();
                        mainMenu mm = new mainMenu();
                        mm.Show();
                        //Sucess su = new Sucess();
                        //su.ShowDialog();
                    }
                    else
                    {
                        lbl_val_invalid.Visible = true;
                    }
                }
                con.Close();
            }
            catch (SqlException)
            {
                error404F err = new error404F();
                err.ShowDialog();
            }
            catch (Exception)
            {
                lbl_val_invalid.Text = "Somthing wrong, Please try again!";
                lbl_val_invalid.Visible = true;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            lbl_val_invalid.Visible = false;
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu mm = new mainMenu();
            mm.Show();
        }
    }
}
