using System;
using System.Net;
using System.Net.Sockets;

namespace CYCU_Course_Selection_Helper.Models
{
    public static class NtpClient
    {
        public static DateTime GetNetworkTime()
        {
            //const string ntpServer = "time.nist.gov";
            //const string ntpServer = "time.cycu.edu.tw";
            const string ntpServer = "time.windows.com";
            byte[] ntpData = new byte[48];

            //  LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)
            ntpData[0] = 0x1B;

            IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;
            IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
            {
                ReceiveTimeout = 3000
            };

            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();


            const byte serverReplyTime = 40;
            //  Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //  Get the seconds fraction
            ulong fractionPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //  Convert From big-endian to little-endian
            intPart = SwapEndian(intPart);
            fractionPart = SwapEndian(fractionPart);

            ulong milliseconds = (intPart * 1000) + ((fractionPart * 1000) / 0x100000000L);

            //  UTC time + 8 
            DateTime networkDateTime = (new DateTime(1900, 1, 1))
                .AddMilliseconds((long)milliseconds).AddHours(8);

            return networkDateTime;
        }

        //  Ref: https://stackoverflow.com/a/3294698/162671
        private static uint SwapEndian(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                          ((x & 0x0000ff00) << 8) +
                          ((x & 0x00ff0000) >> 8) +
                          ((x & 0xff000000) >> 24));
        }
    }
}