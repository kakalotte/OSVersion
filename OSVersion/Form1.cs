using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net.NetworkInformation;

namespace OSVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // добавить инфу о процессоре, пямяти, видеокарте

            var info = "";

            info += "OS Info:" + Environment.NewLine;
            info += string.Format("Name = {0}", OSInfo.Name) + Environment.NewLine;
            info += string.Format("Edition = {0}", OSInfo.Edition) + Environment.NewLine;
            info += string.Format("Service Pack = {0}", OSInfo.ServicePack) + Environment.NewLine;
            info += string.Format("Version = {0}", OSInfo.VersionString) + Environment.NewLine;
            info += string.Format("Bits = {0}", OSInfo.OSBits) + Environment.NewLine + Environment.NewLine;

            info += GetNetworkInterfacesInfo();

            OSInfo_TextBox.Text = info;
        }

        public static string GetNetworkInterfacesInfo()
        {
            var info = "";

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            info += string.Format("Network Interfaces information for {0}:     ",
                    computerProperties.HostName + (computerProperties.DomainName == ""? "" : "." + computerProperties.DomainName)) + Environment.NewLine;
            if (nics == null || nics.Length < 1)
            {
                info += string.Format("  No network interfaces found.");
                return info;
            }

            info += string.Format("  Interfaces count .................... : {0}", nics.Length) + Environment.NewLine + Environment.NewLine;
            foreach (NetworkInterface adapter in nics)
            {
                var test = adapter.GetIPProperties();
                IPInterfaceProperties properties = adapter.GetIPProperties();

                info += string.Format(adapter.Description) + Environment.NewLine;
                info += string.Format(String.Empty.PadLeft(adapter.Description.Length, '=')) + Environment.NewLine;
                info += string.Format("  Interface type .......................... : {0}", adapter.NetworkInterfaceType) + Environment.NewLine;
                info += string.Format("  Physical Address ........................ : {0}",
                           adapter.GetPhysicalAddress().ToString()) + Environment.NewLine;



                foreach (UnicastIPAddressInformation ip in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        info += string.Format("  IP Address ........................ : {0}", ip.Address.ToString()) + Environment.NewLine;
                    }
                }



                info += string.Format("  Operational status ...................... : {0}",
                    adapter.OperationalStatus) + Environment.NewLine;
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                info += string.Format("  IP version .............................. : {0}", versions) + Environment.NewLine;


                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                //info += string.Format("  DNS address .............................. : {0}",
                //    properties.DnsAddresses) + Environment.NewLine;
                info += "  DNS addresses .............................. : ";
                //var test1 = properties.DnsAddresses[0];
                //var t2 = test1.ToString();
                for (int i = 0; i < properties.DnsAddresses.Count; i++)
                {
                    info += properties.DnsAddresses[i].ToString();

                    if (i != properties.DnsAddresses.Count - 1)
                        info += ", ";
                    else
                        info += Environment.NewLine;
                }


                string label;
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    
                    if(ipv4 != null)
                    {
                        info += string.Format("  MTU...................................... : {0}", ipv4.Mtu) + Environment.NewLine;
                        if (ipv4.UsesWins)
                        {

                            IPAddressCollection winsServers = properties.WinsServersAddresses;
                            if (winsServers.Count > 0)
                            {
                                label = "  WINS Servers ............................ :";
                            }
                        }
                    }
                }

                info += string.Format("  DNS enabled ............................. : {0}",
                    properties.IsDnsEnabled) + Environment.NewLine;
                info += string.Format("  Dynamically configured DNS .............. : {0}",
                    properties.IsDynamicDnsEnabled) + Environment.NewLine;
                info += string.Format("  Receive Only ............................ : {0}",
                    adapter.IsReceiveOnly) + Environment.NewLine;
                info += string.Format("  Multicast ............................... : {0}",
                    adapter.SupportsMulticast) + Environment.NewLine;

                info += Environment.NewLine;
            }

            return info;
        }
    }
}
