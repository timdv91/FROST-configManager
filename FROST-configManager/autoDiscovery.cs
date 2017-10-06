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
        //send ping to each IP in this subnet:
        public PingReply sendPing(string _IP,int timeoutDelay)
        {
            //using ping and pingreply to send discovery:
            Ping SubnetPing = new Ping();
            PingReply pingreply = SubnetPing.Send(_IP, timeoutDelay);
            return pingreply;
        }

        //Chech if device treuly is a FROST device by logging in trouch scp:
        public string discoverDeviceCompatibility(string _IP, string _user, string _Password)
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
