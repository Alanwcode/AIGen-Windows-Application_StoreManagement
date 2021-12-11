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

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTechV2;Integrated Security=True");

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
            try
            {
                con.Open();
                SqlCommand ccm = new SqlCommand("select count(OID) from orders where oDate = getdate()", con);
                SqlDataReader dr = ccm.ExecuteReader();
                while (dr.Read())
                {
                    byte[] array = new byte[4];
                    lbl_todayDeals.Text = dr.GetValue(array[0]).ToString();
                }
                ccm.Dispose();
                dr.Close();

                SqlCommand ccmTwo = new SqlCommand("select count(NIC) from customer", con);
                SqlDataReader daTwo = ccmTwo.ExecuteReader();
                while (daTwo.Read())
                {
                    byte[] array = new byte[4];
                    lbl_sumMembers.Text = daTwo.GetValue(array[0]).ToString();
                }
                ccmTwo.Dispose();
                daTwo.Close();

                SqlCommand ccmThree = new SqlCommand("Select count(OID) from orders", con);
                SqlDataReader drThree = ccmThree.ExecuteReader();
                while (drThree.Read())
                {
                    byte[] array = new byte[4];
                    lbl_sumOrders.Text = drThree.GetValue(array[0]).ToString();
                }
                ccmThree.Dispose();
                drThree.Close();

                SqlCommand ccmFoure = new SqlCommand("select sum(price) from products", con);
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
            catch(Exception)
            {
                this.Close();
                mainMenu mm = new mainMenu();
                mm.Show();
                error404F err = new error404F();
                err.Show();
            }
        }
    }
}
