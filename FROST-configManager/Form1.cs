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

        //Starts a discovery for devices on local network:
        private void btnSendDiscoveryPing_Click(object sender, EventArgs e)
        {
            autoDiscovery ad = new autoDiscovery();
            listBox_DevicesDiscoverd.DataSource = ad.getAllFROSTDevices(70);
            
        }

        //event when index of listbox changes, enables btnConnect:
        private void listBox_DevicesDiscoverd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_DevicesDiscoverd.SelectedItems.Count > 0)
                btnConnect.Enabled = true;
            else
                btnConnect.Enabled = false;
        }

        //event when manualconnection textbox input gets larger then 5, enables btnConnect:
        private void txtManualConnectionIP_TextChanged(object sender, EventArgs e)
        {
            if (txtManualConnectionIP.Text.Length > 5)
                btnConnect.Enabled = true;
            else
                btnConnect.Enabled = false;
        }
    }
}
