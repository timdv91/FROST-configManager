using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using WinSCP;

namespace FROST_configManager
{
    class autoDiscovery
    {
        //Main function of this class: 
        public List<string> getAllFROSTDevices(int _subnetRange = 250, int _pingTimeout = 50, string _username = "tim", string _password = "azerty")
        {
            //Create a return list:
            List<string> FrostDeviceList = new List<string>();
            
            //loop all IP's for subnet 192.168.1.x:
            for (int I = 1; I < _subnetRange; I++)
            {
                PingReply pr = sendPing("192.168.1." + I, _pingTimeout); //send ping to detect device on this ip.
                if (pr.Address != null) //if ping was successfull try to identify if device is FROST.
                {
                    string FROSTdeviceName = discoverDeviceCompatibility(pr.Address.ToString(), _username, _password); //Using SCP to connect to the device.
                    //If wrong WinSCP version is installed:
                    if (FROSTdeviceName == "< __VERSION ERROR: Need WinSCP v5.11.1.0__ >")
                    {
                        Console.WriteLine("returning WinSCP version error.");
                        FrostDeviceList.Add(FROSTdeviceName);
                        return FrostDeviceList;
                    }
                    //if other error occuers:
                    if (FROSTdeviceName != "<__FALSE__>") //if returned frostname = "false" then ignore it.
                        FrostDeviceList.Add(FROSTdeviceName + "@" + pr.Address.ToString()); //add valid device to returnList.                
                }
            }
            return FrostDeviceList; //return the returnList.
        }

        //send ping to each IP in this subnet:
        PingReply sendPing(string _IP,int timeoutDelay)
        {
            //using ping and pingreply to send discovery:
            Ping SubnetPing = new Ping();
            PingReply pingreply = SubnetPing.Send(_IP, timeoutDelay);
            return pingreply;
        }

        //Chech if device treuly is a FROST device by logging in trouch scp:
        string discoverDeviceCompatibility(string _IP, string _user, string _Password)
        {
            try //if device is not a frost device an exception is thrown!
            {
                SessionOptions so = new SessionOptions();
                so.Protocol = Protocol.Scp;
                so.HostName = _IP;
                so.UserName = _user;
                so.Password = _Password;
                so.GiveUpSecurityAndAcceptAnySshHostKey = true; //no hostkey is used for the moment. Would be nice upgrade for in the near future.

                //create session 's', and open connection using SessionOptions 'so'.
                Session s = new Session();
                s.Open(so);

                //if connecting was successfull, read file containing devicename:
                CommandExecutionResult strOut = s.ExecuteCommand("cat /home/FROST/FROST_DeviceName.conf");

                s.Close(); //close connection.

                //if reading the file was unsuccessfull warn the user:
                if (strOut.IsSuccess != true)
                {
                    Console.WriteLine("Unnamed FROST device found @" + _IP);
                    return "Warning: this device has no filename configuration file!";
                }
                else //if device has a name:
                {
                    Console.WriteLine(strOut.Output.ToString());
                    Console.WriteLine("FROST device found " + strOut.Output.ToString() + "@" + _IP);
                    return strOut.Output.ToString(); //return filedata only, ip is not returned!
                }

            }catch(WinSCP.SessionRemoteException)
            {
                Console.WriteLine("Device on " + _IP + " is not a FROST device!");
                return "<__FALSE__>";
            }
            catch(WinSCP.SessionLocalException)
            {
                Console.WriteLine("Connection failed. Possible wrong WinSCP version installed?");
                return "<__VERSION ERROR: Need WinSCP v5.11.1.0__>";
            }
        }
    }
}
