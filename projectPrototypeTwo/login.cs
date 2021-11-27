using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.Hide();
            reg.ShowDialog();
        }

        private void btn_privacyPolicy_Click(object sender, EventArgs e)
        {
            termsAndconditions tac = new termsAndconditions();
            tac.ShowDialog();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            lbl_val_invalid.Visible = false;
            if (txt_username.Text == "admin" && txt_password.Text == "admin123")
            {
                adminDashboard adD = new adminDashboard();
                adD.Show();
                this.Close();
            }
            else
            {
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
    }
}
