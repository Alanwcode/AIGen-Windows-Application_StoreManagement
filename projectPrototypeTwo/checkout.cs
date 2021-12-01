using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace projectPrototypeTwo
{
    public partial class checkout : Form
    {
        public checkout()
        {
            InitializeComponent();
        }

        private void btn_payNow_Click(object sender, EventArgs e)
        {
            lbl_formValidation.Visible = false;

            if (!Regex.IsMatch(txt_expDate.Text, @"^(0[1-9]|1[0-2])\/?(([0-9]{4}|[0-9]{2})$)"))
            {
                lbl_formValidation.Text = "Card Expire date isn't valid";
                lbl_formValidation.Visible = true;
            }
            else
            {
                Sucess suc = new Sucess();
                suc.ShowDialog();
                this.Close();
            }
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            lbl_formValidation.Visible = false;
        }
    }
}
