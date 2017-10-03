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
    public partial class configManagerForm : Form
    {
        //create a list of SCPc connection managers, usefull for multiple connections @ once:
        List<SCPconnectionManager> SCPcList = new List<SCPconnectionManager>();

        public configManagerForm(List<String> devicesToConnectTo, string _username, string _password)
        {
            InitializeComponent();

            //Open SCP connection to devices:
            foreach (string device in devicesToConnectTo)
            {
                //write information to consol:
                Console.WriteLine(device.ToString() + " UserName = " + _username + " Password = " + _password);

                string _IP = device.ToString(); //For advanced use, no devicename@IP is given. device.toString() contains the correct IP adress data.

                if (device.ToString().Contains('@')) //Using auto discovery, device.toString() contains also the devicename. Using the '@' character as delimiter.
                {
                    //Split deviceName from IP:
                    string[] splitBuf = device.ToString().Split('@');
                    _IP = splitBuf[1];
                }

                //Connect to this device:
                SCPconnectionManager SCPcon = new SCPconnectionManager();
                bool isConnected = SCPcon.openConnection(_IP, _username, _password);

                if(isConnected == false)
                {
                    MessageBox.Show("Could not login on device " + _IP + " Connection canceled!");
                    break;
                }

                //Add this device to connected devicesList for later useage:
                SCPcList.Add(SCPcon);
            }          

            //inform user with a tip if multiple devices are selected:
            if (SCPcList.Count > 1)
            {
                MessageBox.Show("You have selected multiple devices at once. As data could be different between devices, only the information of the first device in the discovery list is shown on the UI.\nSome settings are also read only in this mode and can not be changed.");
                loadDataFromDevices(true); //load data in readonlymode.
            }
            else if(SCPcList.Count == 1)
            {
                //load data from devices to show in UI:
                loadDataFromDevices();
            }
        }

        //Load data from devices config files:
        void loadDataFromDevices(bool blReadOnlyMode = false)
        {
            //Load device information:
            richTextBox_DeviceInformation.Text = SCPcList[0].getDeviceInformation();

            //load device name:
            txtDeviceName.Text = SCPcList[0].getDeviceName();

            //load device measure interval:
            txtMeasurmentInterval.Text = SCPcList[0].getMeasureInterval();

            //add here more configs to load...

            //disable UI components in readOnlyMode:
            if (blReadOnlyMode)
            {
                txtDeviceName.Enabled = false;
                //add here more readonlymode configs...
            }
        }

        //Saves data to devices config files:
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save device name to file:
            if(txtDeviceName.Text.Length > 0)
                SCPcList[0].setDeviceName(txtDeviceName.Text);

            //Save Measurement interval to file:
            try
            {
                if (Convert.ToInt32(txtMeasurmentInterval.Text) > 0)
                {
                    foreach (SCPconnectionManager con in SCPcList)
                        con.setMeasureInterval(txtMeasurmentInterval.Text);
                }
            }catch(FormatException)
            {
                MessageBox.Show("Measurement interval contains invalid chars. NOT SAVED!");
            }

            //add here more configs to save...

            MessageBox.Show("Config saved.");
        }

        //Exit this window, closes connections first.
        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (SCPconnectionManager connection in SCPcList)
                connection.closeConnection();

            this.Close();
        }

    }
}
