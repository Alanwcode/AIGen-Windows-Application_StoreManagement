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

        private void btn_login_Click(object sender, EventArgs e)
        {

            lbl_val_invalid.Visible = false;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select count(*) from adminLogin where username = '" + txt_username.Text + "' and passUser = '" + txt_password.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                adminDashboardHome adD = new adminDashboardHome();
                adD.Show();
                this.Close();
            }
            else
            {
                SqlDataAdapter daUL = new SqlDataAdapter("select count(*) from Customer where username = '" + txt_username.Text + "' and cusPassword = '" + txt_password.Text + "'", con);
                DataTable dtUL = new DataTable();
                daUL.Fill(dtUL);

                if (dtUL.Rows[0][0].ToString() == "1")
                {
                    Logins lg = new Logins();
                    lg.saveUsername(txt_username.Text);
                    lg.updateLoginStatus(true);
                    Sucess su = new Sucess();
                    su.Show();
                }
                else
                {
                    lbl_val_invalid.Visible = true;
                }
            }
            con.Close();
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
