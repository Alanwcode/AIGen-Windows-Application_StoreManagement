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
    public partial class adminDashboardOrders : Form
    {
        public adminDashboardOrders()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            adminDashboardHome adH = new adminDashboardHome();
            adH.Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.Close();
            adminDashboardMembers adM = new adminDashboardMembers();
            adM.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            adminDashboardStocks adS = new adminDashboardStocks();
            this.Close();
            adS.Show();
        }

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            mainMenu mm = new mainMenu();
            mm.Show();
            this.Hide();
        }

        private void adminDashboardOrders_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");

            con.Open();
            da = new SqlDataAdapter("Select * from Orders", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgw_Orders.DataSource = dt;
            con.Close();
        }
    }
}
