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
    public partial class types : Form
    {
        public types()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void btn_contactUs_Click(object sender, EventArgs e)
        {
            contactUs cus = new contactUs();
            cus.ShowDialog();
        }

        private void btn_privacyPolicy_Click(object sender, EventArgs e)
        {
            termsAndconditions tac = new termsAndconditions();
            tac.ShowDialog();
        }

        private void btn_purchaseItemOne_Click(object sender, EventArgs e)
        {
            checkout ch = new checkout("1119",2360);
            ch.ShowDialog();
        }

        private void btn_purchaseItemTwo_Click(object sender, EventArgs e)
        {
            checkout ch = new checkout("1120", 3600);
            ch.ShowDialog();
        }

        private void btn_purchaseItemThree_Click(object sender, EventArgs e)
        {
            checkout ch = new checkout("1121", 3999);
            ch.ShowDialog();
        }

        private void btn_purchaseItemFoure_Click(object sender, EventArgs e)
        {
            checkout ch = new checkout("1122",5399);
            ch.ShowDialog();
        }
    }
}
