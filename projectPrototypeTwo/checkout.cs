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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True");
        string NICNo = "";

        public checkout(string pNum, double price)
        {
            InitializeComponent();

            try
            {
                lbl_productNumber.Text = pNum.ToString();
                lbl_price.Text = price.ToString();
                logs.checkLoginStatus();

                con.Open();
                SqlCommand ccm = new SqlCommand("select cusNIC from customerLogin where username = '" +logs.loggedUserName+ "' ", con);
                SqlDataReader dr = ccm.ExecuteReader();

                while (dr.Read())
                {
                    byte[] array = new byte[4];
                    txt_NIC.Text = dr.GetValue(array[0]).ToString();
                    NICNo = dr.GetValue(array[0]).ToString();
                }
                con.Close();
                ccm.Dispose();
            }
            catch (Exception)
            {
                lbl_formValidation.Text = "Connection Error, Customer NIC not Found.";
                lbl_formValidation.Visible = true;
            }
        }

        Logins logs = new Logins();

        private void btn_payNow_Click(object sender, EventArgs e)
        {
            int cCount = 0;

            lbl_formValidation.Visible = false;
            txt_expDate.BorderColor = Color.DarkGray;
            txt_addressOne.BorderColor = Color.DarkGray;
            txt_addressTwo.BorderColor = Color.DarkGray;
            txt_cardVal.BorderColor = Color.DarkGray;
            txt_city.BorderColor = Color.DarkGray;
            txt_cvv.BorderColor = Color.DarkGray;
            txt_NIC.BorderColor = Color.DarkGray;
            txt_zipCode.BorderColor = Color.DarkGray;

            if (!Regex.IsMatch(txt_expDate.Text, @"^(0[1-9]|1[0-2])\/?(([0-9]{4}|[0-9]{2})$)"))
            {
                lbl_formValidation.Text = "Card Expire date isn't valid";
                lbl_formValidation.Visible = true;
                txt_expDate.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }


            if (String.IsNullOrEmpty(txt_NIC.Text))
            {
                txt_NIC.BorderColor = Color.Red;
            }
            else if (NICNo != txt_NIC.Text)
            {
                txt_NIC.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }


            if (String.IsNullOrEmpty(txt_addressOne.Text))
            {
                txt_addressOne.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }


            if (String.IsNullOrEmpty(txt_cardVal.Text))
            {
                txt_cardVal.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }


            if (String.IsNullOrEmpty(txt_city.Text))
            {
                txt_city.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }


            if (String.IsNullOrEmpty(txt_cvv.Text))
            {
                txt_cvv.BorderColor = Color.Red;
            }
            else if(txt_cvv.Text.Length != 3)
            {
                txt_cvv.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }


            if (String.IsNullOrEmpty(txt_zipCode.Text))
            {
                txt_zipCode.BorderColor = Color.Red;
            }
            else
            {
                cCount = cCount + 1;
            }

            //cardValidate cVal = new cardValidate();
            //int val = cVal.IsCreditCardInfoValid(txt_cardVal.Text, txt_expDate.Text, txt_cvv.Text);


            try
            {
                if (cCount != 7)
                {
                    lbl_formValidation.Text = "Some Feild/s are Invalid, Please check again!";
                    lbl_formValidation.Visible = true;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into orders (cusNIC, PID, deliveryAddress) values ('" + txt_NIC.Text + "','" + lbl_productNumber.Text + "','" + txt_addressOne.Text + ", " + txt_addressTwo.Text + ", " + txt_city.Text + "')", con);
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
            catch(FormatException)
            {
                lbl_formValidation.Text = "Invalid Format!";
            }
            catch (Exception)
            {
                lbl_formValidation.Text = "Something went wrong please try again!";
            }
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            lbl_formValidation.Visible = false;
            if (logs.loginStatus == false)
            {
                MessageBox.Show("You are not Looggedin Please Login before Purchase.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }
    }
}
