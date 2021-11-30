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
    public partial class adminDashboardStocks : Form
    {
        public adminDashboardStocks()
        {
            InitializeComponent();
        }

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
    }
}
