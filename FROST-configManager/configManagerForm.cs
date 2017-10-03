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
                SCPcon.openConnection(_IP, _username, _password);

                //Add this device to connected devicesList for later useage:
                SCPcList.Add(SCPcon);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            foreach (SCPconnectionManager connection in SCPcList)
                connection.closeConnection();

            this.Close();
        }
    }
}
