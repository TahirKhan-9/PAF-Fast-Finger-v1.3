using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Usman.CodeBlocks.Networking
{
    public class NetworkHelper
    {

        public static string GetMac(string ip)
        {
            IPAddress ipAddr = IPAddress.Parse(ip);
            PhysicalAddress macAddress = GetDestinationMacAddress(ipAddr);
            return macAddress.ToString();
        }

        public static PhysicalAddress GetDestinationMacAddress(System.Net.IPAddress address)

        {

            return GetDestinationMacAddress(address, System.Net.IPAddress.Any);

        }

        public static PhysicalAddress GetDestinationMacAddress(System.Net.IPAddress address, System.Net.IPAddress sourceAddress)

        {

            byte[] macAddrBytes = GetDestinationMacAddressBytes(address, sourceAddress);

            PhysicalAddress macAddress = new PhysicalAddress(macAddrBytes);

            return macAddress;

        }

        public static byte[] GetDestinationMacAddressBytes(System.Net.IPAddress address, System.Net.IPAddress sourceAddress)

        {

            if (address.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            {

                string error = new ArgumentException("Only supports IPv4 Addresses.").Message;
                //File.AppendAllText(System.Windows.Forms.Application.StartupPath + "//errlog" + DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + ": " + error + "\n");
                //throw new ArgumentException("Only supports IPv4 Addresses.");

            }

            Int32 addrInt = IpAddressAsInt32(address);

            Int32 srcAddrInt = IpAddressAsInt32(address);

            //

            const int MacAddressLength = 6;// 48bits

            byte[] macAddress = new byte[MacAddressLength];

            Int32 macAddrLen = macAddress.Length;

            Int32 ret = NativeMethods.SendArp(addrInt, srcAddrInt, macAddress, ref macAddrLen);

            if (ret != 0)
            {

                string error = new System.ComponentModel.Win32Exception(ret).Message;
                //File.AppendAllText(System.Windows.Forms.Application.StartupPath + "//errlog" + DateTime.Now.ToString("ddMMyyyy") + ".txt", DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss") + ": " + error + "\n");

            }

            //System.Diagnostics.Debug.Assert(macAddrLen == MacAddressLength, "out macAddrLen==4");

            return macAddress;

        }

        private static Int32 IpAddressAsInt32(System.Net.IPAddress address)

        {

            byte[] ipAddrBytes = address.GetAddressBytes();

            //System.Diagnostics.Debug.Assert(ipAddrBytes.Length == 4, "GetAddressBytes: .Length==4");

            Int32 addrInt = BitConverter.ToInt32(ipAddrBytes, 0);

            return addrInt;

        }

        static class NativeMethods

        {

            /// <summary>

            /// Sends an ARP request to obtain the physical address that corresponds

            /// to the specified destination IP address.

            /// </summary>

            /// -

            /// <param name="destIpAddress">Destination IP address, in the form of

            /// a <see cref="T:System.Int32"/>. The ARP request attempts to obtain

            /// the physical address that corresponds to this IP address.

            /// </param>

            /// <param name="srcIpAddress">IP address of the sender, in the form of

            /// a <see cref="T:System.Int32"/>. This parameter is optional. The caller

            /// may specify zero for the parameter.

            /// </param>

            /// <param name="macAddress">

            /// </param>

            /// <param name="macAddressLength">On input, specifies the maximum buffer

            /// size the user has set aside at pMacAddr to receive the MAC address,

            /// in bytes. On output, specifies the number of bytes written to

            /// pMacAddr.</param>

            /// -

            /// <returns>If the function succeeds, the return value is NO_ERROR.

            /// If the function fails, use FormatMessage to obtain the message string

            /// for the returned error.

            /// </returns>

            [System.Runtime.InteropServices.DllImport("Iphlpapi.dll", EntryPoint = "SendARP")]

            internal extern static Int32 SendArp(Int32 destIpAddress, Int32 srcIpAddress,

            byte[] macAddress, ref Int32 macAddressLength);

        }

    }
}
