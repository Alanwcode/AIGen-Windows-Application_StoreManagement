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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.ShowDialog();
            this.Close();
        }

        private void btn_customOrder_Click(object sender, EventArgs e)
        {
            customOrder co = new customOrder();
            co.ShowDialog();
        }

        private void btn_existingOrder_Click(object sender, EventArgs e)
        {
            types tEI = new types();
            tEI.Show();
            this.Hide();
        }

        private void btn_privacyPolicy_Click(object sender, EventArgs e)
        {
            termsAndconditions tac = new termsAndconditions();
            tac.ShowDialog();
        }

        private void btn_contactUs_Click(object sender, EventArgs e)
        {
            contactUs cus = new contactUs();
            cus.ShowDialog();
        }
    }
}
