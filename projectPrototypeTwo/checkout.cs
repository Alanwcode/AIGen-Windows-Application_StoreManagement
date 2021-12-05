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
using System.Data.SqlClient;

namespace projectPrototypeTwo
{
    public partial class checkout : Form
    {
        public checkout(string pNum, double price)
        {
            InitializeComponent();
            lbl_productNumber.Text = pNum.ToString();
            lbl_price.Text = price.ToString();
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
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Orders (cusNIC, PID, deliveryAddress) values ('"+txt_NIC.Text+"','"+lbl_productNumber.Text+"','"+txt_addressOne.Text +", "+ txt_addressTwo.Text + ", " + txt_city.Text +"')", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    Sucess suc = new Sucess();
                    suc.ShowDialog();
                }
                else
                {
                    error404F err = new error404F();
                    err.ShowDialog();
                }
                con.Close();
                cmd.Dispose();
            }
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            lbl_formValidation.Visible = false;
        }
    }
}
