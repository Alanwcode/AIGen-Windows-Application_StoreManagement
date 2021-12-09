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
    public partial class adminDashboardStocks : Form
    {
        public adminDashboardStocks()
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

        private void btn_mainMenu_Click(object sender, EventArgs e)
        {
            mainMenu mm = new mainMenu();
            mm.Show();
            this.Hide();
        }

        private void adminDashboardStocks_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");

                con.Open();
                da = new SqlDataAdapter("select distinct * from customProducts;", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgw_vProducts.DataSource = dt;
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
