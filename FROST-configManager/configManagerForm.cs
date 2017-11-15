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

        private void checkBox_MySqlTableNameUseDeviceName_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_MySqlTableNameUseDeviceName.Checked == true)
            {
                txtMySqlServerTableName.Enabled = false;
                txtMySqlServerTableName.Text = txtDeviceName.Text;
            }
            else
                txtMySqlServerTableName.Enabled = true;
        }

        private void btnSaveNewEmailAdress_Click(object sender, EventArgs e)
        {
            if(txtNewEmailAdress.Text.Length > 0 && txtNewEmailAdress.Text.Contains('@'))
            {
                listBox_EmailAdresses.Items.Add(txtNewEmailAdress.Text);
                txtNewEmailAdress.Clear();
            }
        }

        private void txtNewEmailAdress_TextChanged(object sender, EventArgs e)
        {
            if(txtNewEmailAdress.Text.Contains('@'))
                btnSaveNewEmailAdress.Enabled = true;
            else
                btnSaveNewEmailAdress.Enabled = false;
        }

        private void listBox_EmailAdresses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_EmailAdresses.SelectedItems.Count > 0)
                btnDeleteSelectedEmailAdress.Enabled = true;
            else
                btnDeleteSelectedEmailAdress.Enabled = false;
        }

        private void btnDeleteSelectedEmailAdress_Click(object sender, EventArgs e)
        {
            for(int i = listBox_EmailAdresses.SelectedIndices.Count-1;i>=0;i--)
            {
                listBox_EmailAdresses.Items.RemoveAt(listBox_EmailAdresses.SelectedIndices[i]);
            }
        }

        private void btnCreateBackupOfLogFiles_Click(object sender, EventArgs e)
        {
            bool blIsSuccess = false;
            foreach (SCPconnectionManager device in SCPcList) //Loop all selected devices.
            {
                blIsSuccess = device.getLogFiles(); //Downloads file direct from SCPconnectionManager to hdd.

                if (blIsSuccess == false) //If backing up failes, show error message to user. --> to add in next update: find way to add devicnename where te failure occured.
                {
                    MessageBox.Show("ERROR while downloading log files from FROST device: " + txtDeviceName.Text);
                    return;
                }
            }

            if(blIsSuccess == true)
                MessageBox.Show("Backup completed.");
        }

        private void btnConfirmTableDeletion_Click(object sender, EventArgs e)
        {
            if (checkBox_TableDeletionConfirmation.Checked == true)
            {
                foreach (SCPconnectionManager device in SCPcList) //loop for all selected devices.
                {
                    bool blRetVal = device.removeDeviceTableFromDatabase();
                    if (blRetVal == false)
                        MessageBox.Show("Error removing table for: " + device.getDeviceName().ToString());
                }
            }
            else
                MessageBox.Show("Removal of all data inside the tables for ALL selected devices! Please check the confirm checkbox before pressing the button.");
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

            //load device temperature ranges (min & max) into textboxes:
            string[] tempRanges = SCPcList[0].getTemperatureRanges();
            txtTempRangeMin.Text = tempRanges[0]; //contains min temp.
            txtTempRangeMax.Text = tempRanges[1]; //contains max temp.

        //Email adresses tab:
        //========================
            foreach (string emailAddress in SCPcList[0].getMailList())
            {
                if(emailAddress.Contains('@'))
                    listBox_EmailAdresses.Items.Add(emailAddress);
            }
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

            if (txtMySqlServerTableName.Text == txtDeviceName.Text) //set checkbox true on load if both table and device name are equal.
                checkBox_MySqlTableNameUseDeviceName.Checked = true;

            //FROST device left over diskspace on memory card:
            //================================================
            string[] diskUsageArr = SCPcList[0].getDeviceDiskUsage();
            if (diskUsageArr.Length > 4)
            {
                progressBar_DiskUsage.Value = Convert.ToInt32(diskUsageArr[4].TrimEnd('%'));
                lblDiskUsage.Text += "\nTotal diskspace: " + diskUsageArr[1] + "\nUsed diskspace: " + diskUsageArr[2] + "\nAvailable diskspace: " + diskUsageArr[3];
            } //else: warning using messagebox is normaly catched inside the scp class.


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
                if (Convert.ToInt32(txtMeasurmentInterval.Text) >= 10)
                {
                    foreach (SCPconnectionManager device in SCPcList)
                    {
                        blIsSuccess = device.setMeasureInterval(txtMeasurmentInterval.Text);
                        if (blIsSuccess == false)
                            strErrorMsg += "ERROR saving measurement interval.\n";
                    }
                }
                else
                {
                    MessageBox.Show("Interval can not be smaller than 10");
                    strErrorMsg += "WARNING saving measurement interval.\n";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Measurement interval contains invalid chars. NOT SAVED!");
            }

            //Save Temperature ranges to file:
            //======================================================================
            try
            {
                if (Convert.ToInt32(txtTempRangeMin.Text) < Convert.ToInt32(txtTempRangeMax.Text))
                {
                    foreach (SCPconnectionManager device in SCPcList)
                    {
                        blIsSuccess = device.setTemperatureRanges(txtTempRangeMin.Text, txtTempRangeMax.Text);
                        if (blIsSuccess == false)
                            strErrorMsg += "ERROR saving Temperature ranges.\n";
                    }
                }
                else
                {
                    MessageBox.Show("Minimum temperature can not be larger than maximum temperature...");
                    strErrorMsg += "WARNING saving Temperature ranges.\n";
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Temperature ranges contains invalid chars. NOT SAVED!");
            }

            //Save new maillist to file:
            //======================================================================
            try
            {
                foreach (SCPconnectionManager device in SCPcList)
                {
                    blIsSuccess = device.setMailList(listBox_EmailAdresses.Items.Cast<string>().ToList());
                    if (blIsSuccess == false)
                        strErrorMsg += "ERROR saving maillist.\n";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Saving maillist exception!");
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
                    device.setMySqlSettings(checkBox_DisableMySQL.Checked, txtMySqlServerIP.Text, txtMySqlServerUsername.Text, txtMySqlServerPassword.Text, txtMySqlServerDatabaseName.Text, txtMySqlServerTableName.Text, checkBox_MySqlTableNameUseDeviceName.Checked);

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
