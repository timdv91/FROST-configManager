using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinSCP;
using System.Threading;
using System.IO;

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
        public bool setNetworkSettings(string _Password, bool _DHCPactive, bool _rebootDevice, string _IP = "0.0.0.0", string _NM = "255.255.255.0", string _GW = "192.168.1.1")
        {
            //set ip on "0.0.0.0" when dhcp is enabled, this value is used as check for the ui on load:
            if(_DHCPactive == true)
                _IP = "0.0.0.0";

            //Save data to the config file:
            string netConfigFileData = "auto eth0\n\tiface eth0 inet static\n\t\taddress " + _IP + "\n\t\tnetmask " + _NM + "\n\t\tgateway " + _GW;
            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + netConfigFileData + "\" > /home/FROST/FROST_NetworkSettings.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());

            //if above code has error, quit here and return false:
            if (strOut.IsSuccess == false)
                return false;

            //if above code runs fine: copy the config file to the correct location:
            if (_DHCPactive == false)
            {
                s.ExecuteCommand("echo " + _Password + " | sudo -S cp /home/FROST/FROST_NetworkSettings.conf /etc/network/interfaces"); //Copy config file to etc/network/interfaces:
                strOut = s.ExecuteCommand("diff /home/FROST/FROST_NetworkSettings.conf /etc/network/interfaces"); //strouput.IsSuccess of above line always returns false? Fix later on in code using this diff.
            }
            else
            {
                s.ExecuteCommand("echo " + _Password + " | sudo -S cp /etc/network/interfaces.back /etc/network/interfaces"); //Copy interfaces backup file back to etc/network/interfaces:
                strOut = s.ExecuteCommand("diff /etc/network/interfaces.back /etc/network/interfaces"); //strouput.IsSuccess of above line always returns false? Fix later on in code using this diff.
            }

            //As strouput.IsSuccess on the copy 'cp' line always returns false, I fix it using the 'diff' command. The diff command compares the two files after copying. 
            //If both files are equal then nothing is in strOut.Output (null). This triggers NullReferenceException when copy of file was success.
            try 
            {
                Console.WriteLine("False, \nReturn content: \n" + strOut.Output.ToString()); //if copy of files was success this should trigger NullReferenceException.
                return false; //No exception triggerd on above line? Then somthing went wrong copying the files. :)
            }
            catch(NullReferenceException) //when copy was success continou:
            {
                Console.WriteLine(strOut.IsSuccess.ToString()); //should always be true.
                
                //reboot to change IP:
                if (_rebootDevice == true) //reboot only if requested.
                    setReboot(_Password);

                //return strOut.IsSuccess; //  --> seems to return errors for nothing... All coused by linux that cant act stable on a reboot command...
                return strOut.IsSuccess;
            }          
        }

        //Reboot the device:
        public bool setReboot(string _Password)
        {
            try
            {
                CommandExecutionResult strOut = s.ExecuteCommand("echo " + _Password + " | sudo -S reboot"); //reboot systyem for IP change.
                Thread.Sleep(1000); //hope tis solves the random skips of this command... 
                strOut = s.ExecuteCommand("echo " + _Password + " | sudo -S reboot"); //reboot systyem for IP change.

                if (strOut.IsSuccess == false)
                    return false;

                return strOut.IsSuccess;
            }catch(System.InvalidOperationException)
            {
                return true;
            }catch(WinSCP.SessionLocalException)
            {
                return true;
            }
        }

        //Load MySQL server settings:
        public string[] getMySqlSettings()
        {
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_MySQL.conf");
            Console.WriteLine(strOut.Output.ToString());

            string[] configData = strOut.Output.ToString().Split('\n');
            return configData;
        }

        //Save MySQL server settings:
        public bool setMySqlSettings(bool _blMySqlDisabled, string _IP, string _UserName, string _Password, string _DatabaseName, string _TableName, bool _blTableNameEqualsDeviceName)
        {
            //get the current connected device name:
            if(_blTableNameEqualsDeviceName == true)
                _TableName = getDeviceName(); //if checkbox is checked, use deviceName as tablename.


            //Create config file layout:
            string strConfigFileCreation = _blMySqlDisabled.ToString() + "\n" + _IP + "\n" + _UserName + "\n" + _Password + "\n" + _DatabaseName + "\n" + _TableName;

            //Write config file to file on device:
            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + strConfigFileCreation + "\" > /home/FROST/FROST_MySQL.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());
            return strOut.IsSuccess;
        }

        //Load device temperature ranges:
        public string[] getTemperatureRanges()
        {
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_TempRanges.conf");
            Console.WriteLine(strOut.Output.ToString());
            string[] tempRangeArr = strOut.Output.ToString().Split(':');
            return tempRangeArr;
        }

        //Save device temperature ranges:
        public bool setTemperatureRanges(string _tempRangeMin, string _tempRangeMax)
        {
            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + _tempRangeMin + ":" +_tempRangeMax + "\" > /home/FROST/FROST_TempRanges.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());
            return strOut.IsSuccess;
        }

        //Load device mail list:
        public List<string> getMailList()
        {
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_mailList.conf");
            Console.WriteLine(strOut.Output.ToString());
            List<string> mailListArr = strOut.Output.ToString().Split(' ').ToList<string>();
            return mailListArr;
        }

        //Save device mail list:
        public bool setMailList(List<string> _mailAdressesList)
        {
            string mailList = ""; //create empty mailList var to write to file.

            foreach (string emailAddr in _mailAdressesList) //add all email adresses to this mailList var, inserting a space inbeteween so ssmtp knows how to handle it.
                mailList += emailAddr + " ";

            CommandExecutionResult strOut = s.ExecuteCommand("echo \"" + mailList + "\" > /home/FROST/FROST_mailList.conf");
            Console.WriteLine(strOut.IsSuccess.ToString());
            return strOut.IsSuccess;
        }

        //Save the tempLog and alarmsocketlog file on local machine as backup:
        public bool getLogFiles()
        {
            //get device name from file to use as foldername:
            CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_DeviceName.conf");
            Console.WriteLine(strOut.Output.ToString());

            if (strOut.IsSuccess == false) //if getting devicename failed, return false:
                return false;

            //try to create a new directory named after the device:
            try
            {
                Directory.CreateDirectory(strOut.Output.ToString());
            }
            catch (IOException)
            {
                Console.WriteLine("IOException while creating new folder named after devicename.");
                return false; //if creating dir failed, return false.
            }

            // Download files:
            // Trying the GetFiles function as these files contain lot of data and this would probably be faster:
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;
            TransferOperationResult transferResult;
            transferResult = s.GetFiles("/home/FROST/*.log", AppDomain.CurrentDomain.BaseDirectory.ToString() + '\\' + strOut.Output.ToString() + '\\', false, transferOptions);
            //saves the to download files inside newly created folder. Keeping their default filenames.

            // Throw on any error
            transferResult.Check();

            Console.WriteLine("Downloading the log files endstate: " + transferResult.IsSuccess.ToString());

            if (transferResult.IsSuccess == false)
                Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory.ToString() + '\\' + strOut.Output.ToString() + '\\');

            return transferResult.IsSuccess; //return if transfer was a success.
        }
    }
}
