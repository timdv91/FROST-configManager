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
    }
}
