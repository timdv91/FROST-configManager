using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FROST_configManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendDiscoveryPing_Click(object sender, EventArgs e)
        {
            autoDiscovery ad = new autoDiscovery();
            listBox_DevicesDiscoverd.DataSource = ad.getAllFROSTDevices(70);
        }
    }
}
