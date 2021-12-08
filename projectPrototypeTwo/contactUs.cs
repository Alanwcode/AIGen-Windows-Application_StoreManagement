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
    public partial class contactUs : Form
    {
        public contactUs()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void contactUs_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder mapLocation = new StringBuilder();
                mapLocation.Append("https://www.google.com/maps/@6.9064642,79.8697556,17z");
                webBrowser1.Navigate(mapLocation.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Error loading map", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
