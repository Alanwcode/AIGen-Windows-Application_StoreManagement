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
    public partial class adminDashboardHome : Form
    {
        public adminDashboardHome()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            adminDashboardOrders adO = new adminDashboardOrders();
            adO.Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            adminDashboardMembers adM = new adminDashboardMembers();
            adM.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            adminDashboardStocks adS = new adminDashboardStocks();
            adS.Show();
        }

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            mainMenu mm = new mainMenu();
            mm.Show();
            this.Hide();
        }

        private void adminDashboardHome_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand ccm = new SqlCommand("select count(OID) from Orders where oDate = getdate()", con);
            SqlDataReader dr = ccm.ExecuteReader();
            string tDeals = "";
            while (dr.Read())
            {
                byte[] array = new byte[4];
                tDeals = dr.GetValue(array[0]).ToString();
            }
            lbl_todayDeals.Text = tDeals;
            ccm.Dispose();
            dr.Close();

            SqlCommand ccmTwo = new SqlCommand("select count(NIC) from Customer", con);
            SqlDataReader daTwo = ccmTwo.ExecuteReader();
            while (daTwo.Read())
            {
                byte[] array = new byte[4];
                lbl_sumMembers.Text = daTwo.GetValue(array[0]).ToString();
            }
            ccmTwo.Dispose();
            daTwo.Close();

            SqlCommand ccmThree = new SqlCommand("Select count(OID) from Orders", con);
            SqlDataReader drThree = ccmThree.ExecuteReader();
            while (drThree.Read())
            {
                byte[] array = new byte[4];
                lbl_sumOrders.Text = drThree.GetValue(array[0]).ToString();
            }
            ccmThree.Dispose();
            drThree.Close();

            SqlCommand ccmFoure = new SqlCommand("select sum(price) from customProducts", con);
            SqlDataReader drF = ccmFoure.ExecuteReader();
            while (drF.Read())
            {
                byte[] array = new byte[4];
                lbl_sumSales.Text = drF.GetValue(array[0]).ToString();
            }
            ccmFoure.Dispose();
            drF.Close();

            con.Close();
        }
    }
}
