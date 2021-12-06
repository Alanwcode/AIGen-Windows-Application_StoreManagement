﻿using System;
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
    public partial class adminDashboardMembers : Form
    {
        public adminDashboardMembers()
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

        private void adminDashboardMembers_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");

            con.Open();
            da = new SqlDataAdapter("Select NIC, cusName, email, tel from Customer", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgw_Members.DataSource = dt;
            con.Close();
        }
        //Part not workin correctly
        private void btn_search_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");
            con.Open();
            da = new SqlDataAdapter("Select NIC, cusName, email, tel from Customer where cusName like ('%"+txt_nameOrNic.Text+"%') or NIC like('% +" + txt_nameOrNic.Text + " + %')", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgw_Members.DataSource = dt;
            con.Close();
        }
    }
}
