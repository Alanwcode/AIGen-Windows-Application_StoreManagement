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
    public partial class customOrder : Form
    {
        public customOrder()
        {
            InitializeComponent();
        }

        double price, Dprice = 4899;
        double colorPrice = 0;
        double cameraPrice = 0;
        double voiceControl = 0;
        double remoteAccess = 0;
        double integrate = 0;

        string color = "white", intergration = "None";
        int camQualityCh = 3, remoteAccessCh = 0, voiceControlCh = 0; 

        private void btn_applyColorChange_Click(object sender, EventArgs e)
        {
            colorPrice = 0;
            Dprice = 4899;
            if (rad_white.Checked)
            {
                pbx_blue.Visible = false;
                pbx_red.Visible = false;
                pbx_yellow.Visible = false;
                pbx_white.Visible = true;
                colorPrice = 0;
                color = "White";
            }
            else if (rad_blue.Checked)
            {
                pbx_blue.Visible = true;
                pbx_red.Visible = false;
                pbx_yellow.Visible = false;
                pbx_white.Visible = false;
                colorPrice = 400;
                color = "Blue";
            }
            else if (rad_red.Checked)
            {
                pbx_blue.Visible = false;
                pbx_red.Visible = true;
                pbx_yellow.Visible = false;
                pbx_white.Visible = false;
                colorPrice = 550;
                color = "Red";
            }
            else if (rad_yellow.Checked)
            {
                pbx_blue.Visible = false;
                pbx_red.Visible = false;
                pbx_yellow.Visible = true;
                pbx_white.Visible = false;
                colorPrice = 200;
                color = "Yellow";
            }
            else
            {
                messageBox mbx = new messageBox();
                mbx.ShowDialog();
            }
            price = Dprice + colorPrice + cameraPrice + voiceControl + remoteAccess + integrate;
            lbl_totalPrice.Text = price.ToString() + " USD";
        }

        private void pbx_yellow_Click(object sender, EventArgs e)
        {

        }

        private void customOrder_Load(object sender, EventArgs e)
        {
            pbx_blue.Visible = false;
            pbx_red.Visible = false;
            pbx_yellow.Visible = false;
            pbx_white.Visible = true;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            price = 4899;
            lbl_totalPrice.Text = price.ToString() + " USD";
            color = "white"; intergration = "None";
            camQualityCh = 3; remoteAccessCh = 0; voiceControlCh = 0;
        }

        private void btn_voiceControl_Click(object sender, EventArgs e)
        {
            voiceControl = 1200;
            price = Dprice + colorPrice + cameraPrice + voiceControl + remoteAccess + integrate;
            lbl_totalPrice.Text = price.ToString() + " USD";
            voiceControlCh = 1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            remoteAccess = 2500;
            price = Dprice + colorPrice + cameraPrice + voiceControl + remoteAccess + integrate;
            lbl_totalPrice.Text = price.ToString() + " USD";
            remoteAccessCh = 1;
        }

        private void btn_intergrate_Click(object sender, EventArgs e)
        {
            if (cmbx_intergration.SelectedIndex == 0)
            {
                integrate = 0;
                intergration = "None";
            }
            else if (cmbx_intergration.SelectedIndex == 1)
            {
                integrate = 300;
                intergration = "Alexa";
            }
            else if (cmbx_intergration.SelectedIndex == 2)
            {
                integrate = 400;
                intergration = "Siri";
            }
            else if (cmbx_intergration.SelectedIndex == 3)
            {
                integrate = 150;
                intergration = "Cortona";
            }
            else
            {
                messageBox mbx = new messageBox();
                mbx.ShowDialog();
            }

            price = Dprice + colorPrice + cameraPrice + voiceControl + remoteAccess + integrate;
            lbl_totalPrice.Text = price.ToString() + " USD";
        }

        private void btn_purchase_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-9PI6981;Initial Catalog=MegaTech;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into customProducts (color, camQuality, intergration, remoteAccess, voiceControl, price) values (@a, @b, @c, @d, @e, @f)", con);
            cmd.Parameters.AddWithValue("a", color.ToString());
            cmd.Parameters.AddWithValue("b", camQualityCh);
            cmd.Parameters.AddWithValue("c", intergration);
            cmd.Parameters.AddWithValue("d", remoteAccessCh);
            cmd.Parameters.AddWithValue("e", voiceControlCh);
            cmd.Parameters.AddWithValue("f", price);

            int i = cmd.ExecuteNonQuery();
            if (i == 1)
            {
                SqlCommand ccm = new SqlCommand("select prodNumber from customProducts where price = @f");
                SqlDataReader dr = ccm.ExecuteReader();
                string prodNum = dr["prodNumber"].ToString();
                checkout ch = new checkout(prodNum, price);
                ch.Show();
                this.Hide();
            }
            else
            {
                error404F err = new error404F();
                err.ShowDialog();
            }

            con.Close();
            cmd.Dispose();
        }

        private void btn_clear_Click_1(object sender, EventArgs e)
        {
            price = 0;
            Dprice = 4899;
            colorPrice = 0;
            cameraPrice = 0;
            voiceControl = 0;
            remoteAccess = 0;
            integrate = 0;

            pbx_blue.Visible = false;
            pbx_red.Visible = false;
            pbx_yellow.Visible = false;
            pbx_white.Visible = true;

            price = Dprice + colorPrice + cameraPrice + voiceControl + remoteAccess + integrate;
            lbl_totalPrice.Text = price.ToString() + " USD";
        }

        private void btn_applyCamera_Click(object sender, EventArgs e)
        {
            cameraPrice = 0;
            if (cmbx_camera.SelectedIndex == 0)
            {
                cameraPrice = 0;
                camQualityCh = 3;
            }else if (cmbx_camera.SelectedIndex == 1)
            {
                cameraPrice = 600;
                camQualityCh = 8;
            }else if (cmbx_camera.SelectedIndex == 2)
            {
                cameraPrice = 800;
                camQualityCh = 12;
            }
            else
            {
                messageBox mbx = new messageBox();
                mbx.ShowDialog();
            }

            price = Dprice + colorPrice + cameraPrice + voiceControl + remoteAccess + integrate;
            lbl_totalPrice.Text = price.ToString() + " USD";
        }
    }
}
