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
    }
}
