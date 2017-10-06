using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace FROST_configManager
{
    public partial class Form1 : Form
    {
        //declarating this public makes login credentials publicly available :).
        loginForm loginF = new loginForm();

        //declarating this public makes backgroundworker public available :).
        BackgroundWorker BW0 = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();

            //set backgroundworkers propertys:
            BW0.WorkerReportsProgress = true;
            BW0.RunWorkerCompleted += BW0_RunWorkerCompleted;
            BW0.DoWork += BW0_DoWork;
            BW0.ProgressChanged += BW0_ProgressChanged;
        }


        //Starts a discovery for devices on local network:
        private void btnSendDiscoveryPing_Click(object sender, EventArgs e)
        {
            //Show login form:
            var result = loginF.ShowDialog();

            //if login form has been submited, continue:
            progressBar1.Maximum = 30;
            if (result == DialogResult.OK)
                BW0.RunWorkerAsync(BW0);
            
        }

        //=============================================================================
        //Background workers doing there job:
        //=============================================================================
        private void BW0_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int I = 1; I < progressBar1.Maximum; I++)
            {
                autoDiscovery ad = new autoDiscovery();
                PingReply pr = ad.sendPing("192.168.1." + I, 50);
                if (pr != null)
                {
                    try
                    {
                        string FROSTdeviceName = ad.discoverDeviceCompatibility(pr.Address.ToString(), loginF.username, loginF.password); //Using SCP to connect to the device.

                        //If wrong WinSCP version is installed:
                        if (FROSTdeviceName == "< __VERSION ERROR: Need WinSCP v5.11.1.0__ >")
                        {
                            Console.WriteLine("returning WinSCP version error.");
                            BW0.ReportProgress(I, FROSTdeviceName);
                        }
                        //if other error occuers:
                        if (FROSTdeviceName != "<__FALSE__>") //if returned frostname = "false" then ignore it.
                            BW0.ReportProgress(I, FROSTdeviceName + "@" + pr.Address.ToString()); //add valid device to returnList.  
                            
                    }
                    catch (NullReferenceException)
                    {
                        BW0.ReportProgress(I, null);
                    }
                }
            }
        }

        private void BW0_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if(e.UserState != null)
                listBox_DevicesDiscoverd.Items.Add(e.UserState.ToString());
        }

        private void BW0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Maximum;

            if (listBox_DevicesDiscoverd.Items.Count <= 0)
                MessageBox.Show("No FROST devices could be discovered. Is the given username or password correct?");
            else
                MessageBox.Show("Discovery completed.");
        }

        //=============================================================================
        //=============================================================================


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
