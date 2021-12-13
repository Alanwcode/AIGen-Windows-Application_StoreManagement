using System;
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
    public partial class changePassword : Form
    {
        string NIC = "";

        public changePassword(string nic)
        {
            NIC = nic;
            InitializeComponent();
            txt_password.PasswordChar = '*';
            txt_password.MaxLength = 10;
            txt_confirmPassword.PasswordChar = '*';
            txt_confirmPassword.MaxLength = 10;
        }

        private void changePassword_Load(object sender, EventArgs e)
        {
            lbl_valPassword.Visible = false;
            lbl_valConfirmPassword.Visible = false;

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int count = 0;

            lbl_valPassword.Visible = false;
            lbl_valConfirmPassword.Visible = false;

            if (string.IsNullOrEmpty(txt_password.Text))
            {
                lbl_valPassword.Text = "Feild can't be null";
                lbl_valPassword.Visible = true;
            }
            else if(txt_password.Text.Length != 8)
            {
                lbl_valPassword.Text = "maximum length is 8";
                lbl_valPassword.Visible = true;
            }
            else
            {
                count = count + 1;
            }


            if (string.IsNullOrEmpty(txt_confirmPassword.Text))
            {
                lbl_valConfirmPassword.Text = "Feild can't be null";
                lbl_valConfirmPassword.Visible = true;
            }
            else if (txt_confirmPassword.Text.Length != 8)
            {
                lbl_valConfirmPassword.Text = "maximum length is 8";
                lbl_valConfirmPassword.Visible = true;
            }
            else
            {
                if (txt_confirmPassword.Text != txt_password.Text)
                {
                    lbl_valConfirmPassword.Text = "Password and Confirm Password is different";
                    lbl_valConfirmPassword.Visible = true;
                }
                else
                {
                    count = count + 1;
                }
            }


            if (count == 2)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True");

                con.Open();
                SqlCommand cmd = new SqlCommand("update customerLogin set cusPassword = '"+txt_password.Text+"' where NIC = '" + NIC + "'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Sucess su = new Sucess();
                    su.ShowDialog();
                }
                else
                {
                    error404F er = new error404F();
                    er.ShowDialog();
                }

                con.Close();
            }
        }
    }
}
