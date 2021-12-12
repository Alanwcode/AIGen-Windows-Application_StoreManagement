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
    public partial class profile : Form
    {
        public profile()
        {
            InitializeComponent();
        }

        String NIC = "";

        private void profile_Load(object sender, EventArgs e)
        {
            Logins logs = new Logins();
            logs.readLogData();
            String un = logs.loggedUserName;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True");
            con.Open();
            SqlCommand cmdOne = new SqlCommand("Select cusNIC from customerLogin where username = '"+un+"' ", con);
            SqlDataReader drOne = cmdOne.ExecuteReader();
            while (drOne.Read())
            {
                byte[] array = new byte[4];
                NIC = drOne.GetValue(array[0]).ToString();
                lbl_NICNumber.Text = NIC;
            }
            cmdOne.Dispose();
            drOne.Close();

            SqlCommand cmdTwo = new SqlCommand("Select cusName from customer where NIC = '" +NIC+ "' ", con);
            SqlDataReader drTwo = cmdTwo.ExecuteReader();
            while (drTwo.Read())
            {
                byte[] array = new byte[4];
                lbl_Name.Text = drTwo.GetValue(array[0]).ToString();
            }
            cmdTwo.Dispose();
            drTwo.Close();


            SqlCommand cmdThree = new SqlCommand("Select cusAddress from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drThree = cmdThree.ExecuteReader();
            while (drThree.Read())
            {
                byte[] array = new byte[4];
                lbl_Address.Text = drThree.GetValue(array[0]).ToString();
            }
            cmdThree.Dispose();
            drThree.Close();


            SqlCommand cmdFour = new SqlCommand("Select email from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drFour = cmdFour.ExecuteReader();
            while (drFour.Read())
            {
                byte[] array = new byte[4];
                lbl_emailA.Text = drFour.GetValue(array[0]).ToString();
            }
            cmdFour.Dispose();
            drFour.Close();


            SqlCommand cmdFive = new SqlCommand("Select tel from customer where NIC = '" + NIC + "' ", con);
            SqlDataReader drFive = cmdFive.ExecuteReader();
            while (drFive.Read())
            {
                byte[] array = new byte[4];
                lbl_telNo.Text = drFive.GetValue(array[0]).ToString();
            }
            cmdFive.Dispose();
            drFive.Close();
            con.Close();
        }

        private void btn_editProfile_Click(object sender, EventArgs e)
        {
            editProfile epf = new editProfile(NIC);
            epf.ShowDialog();
        }

        private void btn_passwordChange_Click(object sender, EventArgs e)
        {
            changePassword cp = new changePassword(NIC);
            cp.Show();
        }
    }
}
