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
    public partial class cOrders : Form
    {
        public cOrders()
        {
            InitializeComponent();
            
        }

        private void cOrders_Load(object sender, EventArgs e)
        {
            img_BlueRobot.Visible = false;
            img_redRobo.Visible = false;
            img_YellowRobot.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (rad_blue.Checked)
            {
                img_WhiteRobot.Visible = false;
                img_BlueRobot.Visible = true;
                img_redRobo.Visible = false;
                img_YellowRobot.Visible = false;
            }else if (rad_red.Checked)
            {
                img_WhiteRobot.Visible = false;
                img_BlueRobot.Visible = false;
                img_redRobo.Visible = true;
                img_YellowRobot.Visible = false;
            }
            else if (rad_yellow.Checked)
            {
                img_WhiteRobot.Visible = false;
                img_BlueRobot.Visible = false;
                img_redRobo.Visible = false;
                img_YellowRobot.Visible = true;
            }
            else
            {
                img_WhiteRobot.Visible = true;
                img_BlueRobot.Visible = false;
                img_redRobo.Visible = false;
                img_YellowRobot.Visible = false;
            }
        }
    }
}
