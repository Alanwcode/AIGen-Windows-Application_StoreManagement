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
using System.Text.RegularExpressions;

namespace projectPrototypeTwo
{
    public partial class editProfile : Form
    {
        string NIC = "";

        public editProfile(string nic)
        {
            InitializeComponent();
            NIC = nic;
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True");

        private void editProfile_Load(object sender, EventArgs e)
        {
            lbl_valAddress.Visible = false;
            lbl_valEmail.Visible = false;
            lbl_valName.Visible = false;
            lbl_valTelephone.Visible = false;

            con.Open();

            SqlCommand cmdTwo = new SqlCommand("Select cusName from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drTwo = cmdTwo.ExecuteReader();
            while (drTwo.Read())
            {
                byte[] array = new byte[4];
                txt_name.Text = drTwo.GetValue(array[0]).ToString();
            }
            cmdTwo.Dispose();
            drTwo.Close();


            SqlCommand cmdThree = new SqlCommand("Select cusAddress from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drThree = cmdThree.ExecuteReader();
            while (drThree.Read())
            {
                byte[] array = new byte[4];
                txt_address.Text = drThree.GetValue(array[0]).ToString();
            }
            cmdThree.Dispose();
            drThree.Close();


            SqlCommand cmdFour = new SqlCommand("Select email from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drFour = cmdFour.ExecuteReader();
            while (drFour.Read())
            {
                byte[] array = new byte[4];
                txt_email.Text = drFour.GetValue(array[0]).ToString();
            }
            cmdFour.Dispose();
            drFour.Close();


            SqlCommand cmdFive = new SqlCommand("Select tel from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drFive = cmdFive.ExecuteReader();
            while (drFive.Read())
            {
                byte[] array = new byte[4];
                txt_telephone.Text = drFive.GetValue(array[0]).ToString();
            }
            cmdFive.Dispose();
            drFive.Close();
            con.Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int count = 0;

            lbl_valAddress.Visible = false;
            lbl_valEmail.Visible = false;
            lbl_valName.Visible = false;
            lbl_valTelephone.Visible = false;


            if (string.IsNullOrEmpty(txt_name.Text))
            {
                lbl_valName.Text = "Feild can't be null";
                lbl_valName.Visible = true;

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
            else if (!Regex.IsMatch(txt_email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                lbl_valEmail.Text = "e-mail didn't match with starnderd formats";
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
            else if (!Regex.IsMatch(txt_telephone.Text, @"^(?:7|0|(?:\+94))[0-9]{9,10}$"))
            {
                lbl_valTelephone.Text = "Telephone number didn't match with starnderd formats";
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


            if (count == 4)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update customer set cusName = '" + txt_name.Text + "', cusAddress = '" + txt_address.Text + "', email = '" + txt_email.Text + "', tel = '" + txt_telephone.Text + "' where NIC = '" + NIC + "'", con);
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
            else
            {

            }
        }
    }
}
