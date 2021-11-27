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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            txt_password.PasswordChar = '*';
            txt_password.MaxLength = 10;
            txt_confirmPassword.PasswordChar = '*';
            txt_confirmPassword.MaxLength = 10;
        }

        private void register_Load(object sender, EventArgs e)
        {
            pbx_searchRobotGIF.Visible = false;
            lbl_valAddress.Visible = false;
            lbl_valAgree.Visible = false;
            lbl_valConfirmPassword.Visible = false;
            lbl_valEmail.Visible = false;
            lbl_valName.Visible = false;
            lbl_valNIC.Visible = false;
            lbl_valPassword.Visible = false;
            lbl_valTelephone.Visible = false;
            lbl_valUsername.Visible = false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            pbx_searchRobotGIF.Visible = false;
            lbl_valAddress.Visible = false;
            lbl_valAgree.Visible = false;
            lbl_valConfirmPassword.Visible = false;
            lbl_valEmail.Visible = false;
            lbl_valName.Visible = false;
            lbl_valNIC.Visible = false;
            lbl_valPassword.Visible = false;
            lbl_valTelephone.Visible = false;
            lbl_valUsername.Visible = false;

            txt_address.Clear();
            txt_confirmPassword.Clear();
            txt_email.Clear();
            txt_name.Clear();
            txt_NIC.Clear();
            txt_password.Clear();
            txt_telephone.Clear();
            txt_username.Clear();
            cbx_agree.Checked = false;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (string.IsNullOrEmpty(txt_name.Text))
            {
                lbl_valName.Text = "Feild can't be null";
                lbl_valName.Visible = true;
            }
            else
            {
                count = count + 1;
            }

            if (string.IsNullOrEmpty(txt_NIC.Text))
            {
                lbl_valNIC.Text = "Feild can't be null";
                lbl_valNIC.Visible = true;
            }
            else
            {
                count = count + 1;
            }

            if (string.IsNullOrEmpty(txt_email.Text))
            {
                lbl_valEmail.Text = "Feild can't be null";
                lbl_valEmail.Visible = true;
            }
            else
            {
                count = count + 1;
            }

            if (string.IsNullOrEmpty(txt_telephone.Text))
            {
                lbl_valTelephone.Text = "Feild can't be null";
                lbl_valTelephone.Visible = true;
            }
            else
            {
                count = count + 1;
            }

            if (string.IsNullOrEmpty(txt_address.Text))
            {
                lbl_valAddress.Text = "Feild can't be null";
                lbl_valAddress.Visible = true;
            }
            else
            {
                count = count + 1;
            }

            if (string.IsNullOrEmpty(txt_username.Text))
            {
                lbl_valUsername.Text = "Feild can't be null";
                lbl_valUsername.Visible = true;
            }
            else
            {
                count = count + 1;
            }

            if (string.IsNullOrEmpty(txt_password.Text))
            {
                lbl_valPassword.Text = "Feild can't be null";
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
            else
            {
                count = count + 1;
            }

            

            if(count == 8)
            {
                Sucess suc = new Sucess();
                suc.ShowDialog();
            }
            else
            {
                //messageBox mbx = new messageBox();
                //mbx.ShowDialog();
            }
        }
    }
}
