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
        //user password var, global so we can use it wherever we need:
        string userPassword;

        public configManagerForm(List<String> devicesToConnectTo, string _username, string _password)
        {
            InitializeComponent();

            //set local var to global var:
            userPassword = _password;

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

                if (isConnected == false)
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
                loadDataFromDevices(_username, true); //load data in readonlymode.
            }
            else if (SCPcList.Count == 1)
            {
                //load data from devices to show in UI:
                loadDataFromDevices(_username);
            }
        }

        //Calls function to save data to devices config files:
        private void btnSave_Click(object sender, EventArgs e)
        {
            string strState = saveDataToDevices();
            MessageBox.Show(strState);
        }

        //Exit this window, closes connections first.
        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (SCPconnectionManager connection in SCPcList)
                connection.closeConnection();

            this.Close();
        }

        private void comboBox_DHCPorSTATIC_IP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_DHCPorSTATIC_IP.SelectedIndex == 0)
                panel_NetworkSettingsInputs.Visible = false;
            else
                panel_NetworkSettingsInputs.Visible = true;
        }

        private void checkBox_DisableMySQL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DisableMySQL.Checked == false)
                panel_MySqlServerSettingsInputs.Visible = true;
            else
                panel_MySqlServerSettingsInputs.Visible = false;
        }

        //=================================================================
        //=============Save and Load functions:============================
        //=================================================================

        //Load data from devices config files:
        void loadDataFromDevices(string _username, bool blReadOnlyMode = false)
        {

        //General tab:
        //=============

            //Load device information into richtextbox:
            richTextBox_DeviceInformation.Text = SCPcList[0].getDeviceInformation();

            //load device name into textbox:
            txtDeviceName.Text = SCPcList[0].getDeviceName();

            //load device measure interval into textbox:
            txtMeasurmentInterval.Text = SCPcList[0].getMeasureInterval();


        //users and passwords tab:
        //========================

            //Set textbox containing username:
            txtUsername.Text = _username;


         //Network settings, IP, Netmask, Gateway tab:
         //========================================
            string[] netSettings = SCPcList[0].getNetworkSettings();
            txtIPAdress.Text = netSettings[2];
            txtNetMask.Text = netSettings[3];
            txtGateWay.Text = netSettings[4];

            if (netSettings[2] == "0.0.0.0") //Hide panel with inputs when DHCP is used:
            {
                comboBox_DHCPorSTATIC_IP.SelectedIndex = 0;
                panel_NetworkSettingsInputs.Visible = false;
            }
            else //show panel with inputs when Static is used:
            {
                comboBox_DHCPorSTATIC_IP.SelectedIndex = 1;
                panel_NetworkSettingsInputs.Visible = true;
            }


            //MySQL server settings:
            //========================================
            string[] MySQLConfiguration = SCPcList[0].getMySqlSettings();
            
            if (Convert.ToBoolean(MySQLConfiguration[0]) == true) //Remove input panel from UI when MySQL is disabled.
                panel_MySqlServerSettingsInputs.Visible = false;

            checkBox_DisableMySQL.Checked = Convert.ToBoolean(MySQLConfiguration[0]);
            txtMySqlServerIP.Text = MySQLConfiguration[1];
            txtMySqlServerUsername.Text = MySQLConfiguration[2];
            txtMySqlServerPassword.Text = MySQLConfiguration[3];
            txtMySqlServerDatabaseName.Text = MySQLConfiguration[4];
            txtMySqlServerTableName.Text = MySQLConfiguration[5];

            //add here more configs to load...


            //Read only mode disabled items:
            //==============================

            //disable UI components in readOnlyMode:
            if (blReadOnlyMode)
            {
                txtDeviceName.Enabled = false;
                groupBoxSetNetworkingSettings.Enabled = false;
                //add here more readonlymode configs...
            }
        }

        //Saves data to devices config files:
        string saveDataToDevices()
        {
            bool blIsSuccess = true;
            string strErrorMsg = "";

            //Save device name to file:
            //======================================================================
            try
            {
                if (txtDeviceName.Text.Length > 0)
                    blIsSuccess = SCPcList[0].setDeviceName(txtDeviceName.Text);
                else
                    MessageBox.Show("Device name is empty and ignored. This part is not saved.");
                if (blIsSuccess == false)
                    strErrorMsg += "ERROR saving devicename.\n";
            }catch(Exception)
            {
                MessageBox.Show("Error while saving devicename.");
            }

            //Save Measurement interval to file:
            //======================================================================
            try
            {
                if (Convert.ToInt32(txtMeasurmentInterval.Text) > 0)
                {
                    foreach (SCPconnectionManager device in SCPcList)
                    {
                        blIsSuccess = device.setMeasureInterval(txtMeasurmentInterval.Text);
                        if (blIsSuccess == false)
                            strErrorMsg += "ERROR saving measurement interval.\n";
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Measurement interval contains invalid chars. NOT SAVED!");
            }

            //Save new password:
            //======================================================================
            try
            {
                if (txtSetNewPassword1.Text == txtSetNewPassword2.Text && txtSetNewPassword1.Text.Length > 0 && txtUsername.Text.Length > 0)
                {
                    foreach (SCPconnectionManager device in SCPcList)
                    {
                        blIsSuccess = device.setCurrentUserNewPassword(txtUsername.Text, txtCurrentPassword.Text, txtSetNewPassword1.Text);
                        if (blIsSuccess == false)
                            strErrorMsg += "ERROR saving password.\n";
                    }
                }
            }catch(Exception)
            {
                MessageBox.Show("Error while saving new password.");
            }


            //Save MySQL new server configuration:
            //======================================================================
            try
            {
                foreach (SCPconnectionManager device in SCPcList)
                    device.setMySqlSettings(checkBox_DisableMySQL.Checked, txtMySqlServerIP.Text, txtMySqlServerUsername.Text, txtMySqlServerPassword.Text, txtMySqlServerDatabaseName.Text, txtMySqlServerTableName.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Exception while saving new MySQL server configuration.");
            }


            //add here more configs to save...
            //======================================================================


            //Save new network settings: (keep as last, when checkbox is checked REBOOT is initiated!!!)
            //======================================================================
            try
            {
                if (comboBox_DHCPorSTATIC_IP.SelectedIndex == 1)
                    blIsSuccess = SCPcList[0].setNetworkSettings(userPassword, false, checkBox_NetworkSettingsRebootDevice.Checked, txtIPAdress.Text, txtNetMask.Text, txtGateWay.Text);
                else
                    blIsSuccess = SCPcList[0].setNetworkSettings(userPassword, true, checkBox_NetworkSettingsRebootDevice.Checked);

                if (blIsSuccess == false && checkBox_NetworkSettingsRebootDevice.Checked == false)
                    strErrorMsg += "ERROR saving network settings.\n";

                if (checkBox_NetworkSettingsRebootDevice.Checked == true && strErrorMsg == "") //when no previous errors happend, add 'Save completed' on front.
                    strErrorMsg = "Save completed. Device going down for reboot. Please reconnect on the new IP-address after reboot.";
                else if (checkBox_NetworkSettingsRebootDevice.Checked == true && strErrorMsg != "") //When errors did happen show reboot message wiithout 'save completed' on front.
                    strErrorMsg += "\nDevice going down for reboot. Please reconnect on the new IP-address after reboot.";
            }
            catch(Exception)
            {
                MessageBox.Show("Exception while saving new network configuration.");
            }


            //Close this 'Form' when reboot is active:
            //======================================================================
            if (checkBox_NetworkSettingsRebootDevice.Checked == true)
                this.Close();   
            
            //return if there where errors:
            //======================================================================
            if (strErrorMsg != "")
                return strErrorMsg;
            else
                return "Save completed.";
        }
    }
}
