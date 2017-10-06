using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;

namespace FROST_configManager
{
    class SCPconnectionManager
    {
        //Global declaration of SCP vars:
        SessionOptions so = new SessionOptions();
        Session s = new Session();

        //Open a new connection to device:
        public bool openConnection(string _ip, string _username, string _password)
        {
            try
            {
                so.Protocol = Protocol.Scp;
                so.HostName = _ip;
                so.UserName = _username;
                so.Password = _password;
                so.GiveUpSecurityAndAcceptAnySshHostKey = true;

                s.Open(so);

                Console.WriteLine("Connected to: " + so.HostName.ToString());
                return true;

            }
            catch (WinSCP.SessionRemoteException)
            {
                Console.WriteLine("Connection failed. Possible wrong login credentials?");
                return false;
            }
            catch (WinSCP.SessionLocalException)
            {
                Console.WriteLine("Connection failed. Possible wrong WinSCP version installed?");
                return false;
            }
        }

        //Close connection to device:
        public void closeConnection()
        {
            s.Close();
            Console.WriteLine("Connection closed with device on " + so.HostName.ToString());
        }

        //Load device information:
        public string getDeviceInformation()
        {
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_DeviceInfo.inf");
            Console.WriteLine(strOut.Output.ToString());
            return strOut.Output.ToString();
        }


        //Load device name:
        public string getDeviceName()
        {
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_DeviceName.conf");
            Console.WriteLine(strOut.Output.ToString());
            return strOut.Output.ToString();
        }

        //Save device name:
        public bool setDeviceName(string _deviceName)
        {
            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + _deviceName + "\" > /home/FROST/FROST_DeviceName.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());
            return strOut.IsSuccess;
        }

        //Load device measure inteval:
        public string getMeasureInterval()
        {
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_MeasureInterval.conf");
            Console.WriteLine(strOut.Output.ToString());
            return strOut.Output.ToString();
        }

        //Save device measurement interval:
        public bool setMeasureInterval(string _measureInterval)
        {
            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + _measureInterval + "\" > /home/FROST/FROST_MeasureInterval.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());
            return strOut.IsSuccess;
        }

        //Save user new login password:
        public bool setCurrentUserNewPassword(string userName, string strOldPassword, string strNewPassword)
        {
            CommandExecutionResult strOut = s.ExecuteCommand("echo -e \"" + strOldPassword + "\n" + strNewPassword + "\n" + strNewPassword +"\" | passwd " + userName);
            Console.WriteLine(strOut.IsSuccess.ToString());
            return strOut.IsSuccess;
        }

        //Load network settings:
        public string[] getNetworkSettings()
        {
            string[] netSettings = new string[5];

            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_NetworkSettings.conf");
            Console.WriteLine(strOut.Output.ToString());

            netSettings = strOut.Output.ToString().Split('\n'); //split this file on each line of data.

            for (int I = 2; I < netSettings.Count(); I++) //skip the first 2 lines. Don't need them.
            {
                Console.WriteLine("line var : " + netSettings[I]);
                netSettings[I] = netSettings[I].Split(' ')[3];  //Get the 3th word based on spaces.
                Console.WriteLine("netsettings[I]" + netSettings[I]);
            }

            return netSettings;
        }

        //Save network settings:
        public bool setNetworkSettings(string _IP, string _NM, string _GW, string _Password)
        {
            //Save data to the config file:
            string netConfigFileData = "auto eth0\n\tiface eth0 inet static\n\t\taddress " + _IP + "\n\t\tnetmask " + _NM + "\n\t\tgateway " + _GW;
            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + netConfigFileData + "\" > /home/FROST/FROST_NetworkSettings.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());

            //if above code has error quit here and return false:
            if (strOut.IsSuccess == false)
                return false;

            //if above code runs fine, copy the config file to the correct location:
            //Copy config file to etc/network/interfaces:
            strOut = s.ExecuteCommand("echo " + _Password + " | sudo -S cp /home/FROST/FROST_NetworkSettings.conf /etc/network/interfaces" );

            return strOut.IsSuccess;
        }
    }
}
