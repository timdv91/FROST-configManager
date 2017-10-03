using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FROST_configManager
{
    public partial class Form1 : Form
    {
        //declarating this public makes login credentials publicly available :).
        loginForm loginF = new loginForm();

        public Form1()
        {
            InitializeComponent();
        }

        //Starts a discovery for devices on local network:
        private void btnSendDiscoveryPing_Click(object sender, EventArgs e)
        {
            //Show login form:
            var result = loginF.ShowDialog();

            //if login form has been submited, continue:
            if (result == DialogResult.OK)
            {
                //Start autodiscovery using ping, and downloading filename config from devices where possible:
                autoDiscovery ad = new autoDiscovery();
                listBox_DevicesDiscoverd.DataSource = ad.getAllFROSTDevices(30,50,loginF.username,loginF.password);
            }

            if (listBox_DevicesDiscoverd.Items.Count <= 0)
                MessageBox.Show("No FROST devices could be discovered. Is the given username or password correct?");
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

        //open new form and send list with selected items from listbox:
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //get selected listboxitems to list, or use advanced mode:
            List<string> listboxSelection = listBox_DevicesDiscoverd.SelectedItems.OfType<string>().ToList();
            if (listboxSelection.Count <= 0) //advanced mode:
                listboxSelection.Add(txtManualConnectionIP.Text);

            //Ask for login credentials:
            var result = loginF.ShowDialog(); //show login form.
            if (result == DialogResult.OK) //if login form returns dialogresult.ok continue...
            {
                //open new form, using listboxselection as argument:
                configManagerForm cmf = new configManagerForm(listboxSelection, loginF.username, loginF.password);
                cmf.ShowDialog();
            }
        }
    }
}
