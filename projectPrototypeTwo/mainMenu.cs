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

        }

        private void btn_customOrder_Click(object sender, EventArgs e)
        {
            types tCO = new types();
            tCO.Show();
            this.Hide();
        }

        private void btn_existingOrder_Click(object sender, EventArgs e)
        {
            types tEI = new types();
            tEI.Show();
            this.Hide();
        }
    }
}
