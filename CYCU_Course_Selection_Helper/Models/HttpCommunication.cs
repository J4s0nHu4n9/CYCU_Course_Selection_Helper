using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

namespace CYCU_Course_Selection_Helper
{
    public class HttpCommunication
    {
        private static string _host = "http://140.135.201.1";
        private static string _cookie = "";
        private static string _pageid = "";

        public static bool CheckServerConnect()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send("140.135.201.1", 5000);
                if (pingReply.Status == IPStatus.Success) return true;
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Init(out string secureRandom)
        {
            var response = GrabResponse("/student/sso.srv", "cmd=login_init");

            var getCookie = response.GetResponseHeader("Set-Cookie");
            if (!getCookie.Equals("")) _cookie = getCookie;     //  The cookie has not expired

            var pairs = GetJsonObject(response);

            if (pairs["result"] == "True")
            {
                secureRandom = pairs["secureRandom"];
                return true;
            }
            else
            {
                secureRandom = "";
                return false;
            }
        }

        public static bool Login(string id, string pw, out string msg)
        {
            var response = GrabResponse("/student/sso.srv", "cmd=login&userid=" + id + "&hash=" + pw);
            var pairs = GetJsonObject(response);

            msg = pairs.message;
            if (pairs["result"] == "True")
            {
                _pageid = pairs["pageId"];
                return true;
            }
            else return false;
        }

        public static bool Logout(out string msg)
        {
            var response = GrabResponse("/student/sso.srv", "cmd=logout");
            var pairs = GetJsonObject(response);

            msg = pairs.message;
            if (pairs["result"] == "True") return true;
            else return false;
        }

        public static bool AddRegister(string opcode, out string msg)
        {
            var response = GrabResponse("/student/student/op/StudentCourseView.srv", "cmd=addRegister&op_code=" + opcode);
            if (response == null)
            {
                msg = "未知的錯誤！";
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["result"] == "True")
            {
                msg = "課程 " + opcode + " 篩選登記成功！";
                return true;
            }
            else
            {
                msg = opcode + "\t" + pairs["message"];
                return false;
            }
        }

        public static bool DeleteRegister(string opcode, out string msg)
        {
            var response = GrabResponse("/student/student/op/StudentCourseView.srv", "cmd=deleteRegister&op_code=" + opcode);
            if (response == null)
            {
                msg = "未知的錯誤！";
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["result"] == "True")
            {
                msg = "課程 " + opcode + " 取消篩選登記成功！";
                return true;
            }
            else
            {
                msg = opcode + "\t" + pairs["message"];
                return false;
            }
        }

        public static bool AddSelection(string opcode, out string msg)
        {
            var response = GrabResponse("/student/student/op/StudentCourseView.srv", "cmd=addSelection&op_code=" + opcode);
            if (response == null)
            {
                msg = "未知的錯誤！";
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["result"] == "True")
            {
                msg = "課程 " + opcode + " 加選成功！";
                return true;
            }
            else
            {
                msg = opcode + "\t" + pairs["message"];
                return false;
            }
        }

        public static bool DeleteSelection(string opcode, out string msg)
        {
            var response = GrabResponse("/student/student/op/StudentCourseView.srv", "cmd=deleteSelection&op_code=" + opcode);
            if (response == null)
            {
                msg = "未知的錯誤！";
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["result"] == "True")
            {
                msg = "課程 " + opcode + " 退選成功！";
                return true;
            }
            else
            {
                msg = opcode + "\t" + pairs["message"];
                return false;
            }
        }

        public static bool DeleteAppend(string opcode, out string msg)
        {
            var response = GrabResponse("/student/student/op/StudentCourseView.srv", "cmd=deleteAppend&op_code=" + opcode);
            if (response == null)
            {
                msg = "未知的錯誤！";
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["result"] == "True")
            {
                msg = "課程 " + opcode + " 取消遞補成功！";
                return true;
            }
            else
            {
                msg = opcode + "\t" + pairs["message"];
                return false;
            }
        }

        //  取得已選課程清單
        public static bool GetAllMyCourses(string loginID, out dynamic datas, out string msg)
        {

            var response = GrabResponse(
                "/student/student/op/StudentCourseView.srv",
                "cmd=selectJson&where=sn_status>0 AND idcode='" + loginID + "'");

            if (response == null)
            {
                msg = "未知的錯誤！";
                datas = null;
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["totalRows"] == 0)
            {
                msg = "尚無已選課程";
                datas = null;
            }
            else
            {
                msg = "課程讀取完成";
                datas = pairs["datas"];
            }

            return true;
        }

        //  取得遞補清單
        public static bool GetAllMyCoursesAppend(string loginID, out dynamic datas, out string msg)
        {
            var response = GrabResponse(
                "/student/student/op/StudentCourseView.srv",
                "cmd=selectJson&where=sn_status=-400 AND idcode='" + loginID + "'");

            if (response == null)
            {
                msg = "未知的錯誤！";
                datas = null;
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["totalRows"] == 0)
            {
                msg = "尚無遞補中課程";
                datas = null;
            }
            else
            {
                msg = "遞補清單讀取完成";
                datas = pairs["datas"];
            }

            return true;
        }

        public static bool GetCourseStudents(string opcode, out dynamic datas, out string msg)
        {

            var response = GrabResponse(
                "/student/student/op/StudentCourseView.srv",
                "cmd=selectJson&where=sn_status>0 AND op_code='" + opcode + "'");

            if (response == null)
            {
                msg = "未知的錯誤！";
                datas = null;
                return false;
            }

            var pairs = GetJsonObject(response);

            if (pairs["totalRows"] == 0)
            {
                msg = "尚無人選此課程";
                datas = null;
            }
            else
            {
                msg = "學生列表讀取完成";
                datas = pairs["datas"];
            }

            return true;
        }

        private static dynamic GetJsonObject(HttpWebResponse inputResponse)
        {
            var reader = new StreamReader(inputResponse.GetResponseStream());
            dynamic content = JsonConvert.DeserializeObject(reader.ReadToEnd());

            return content;
        }

        public static HttpWebResponse GrabResponse(string _dir, string _cmd)
        {
            try
            {
                var url = _host + _dir;
                var uri = new Uri(url);

                HttpWebResponse response;

                // Send Login Informations
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.Host = "csys.cycu.edu.tw";
                request.KeepAlive = true;
                request.Headers.Add("Origin", "http://csys.cycu.edu.tw");
                request.Headers.Add("Page-Id", _pageid);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/55.0.2883.87 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF8";
                request.Accept = "*/*";
                request.Headers.Add("DNT", "1");
                request.Referer = "http://csys.cycu.edu.tw/student/";
                request.Headers.Add("Accept-Encoding", "gzip, deflate");
                request.Headers.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.6,en;q=0.4");
                request.Headers.Add("Cookie", _cookie);

                byte[] bs = Encoding.UTF8.GetBytes(_cmd);
                request.GetRequestStream().Write(bs, 0, bs.Length);
                request.ServicePoint.Expect100Continue = false;

                response = (HttpWebResponse)request.GetResponse();

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class NTPClient
    {
        public static DateTime GetNetworkTime()
        {
            //const string ntpServer = "time.nist.gov";
            //const string ntpServer = "time.cycu.edu.tw";
            const string ntpServer = "time.windows.com";
            byte[] ntpData = new byte[48];

            //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)
            ntpData[0] = 0x1B;

            IPAddress[] addresses = Dns.GetHostEntry(ntpServer).AddressList;
            IPEndPoint ipEndPoint = new IPEndPoint(addresses[0], 123);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.ReceiveTimeout = 3000;
            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();


            const byte serverReplyTime = 40;
            //Get the seconds part
            ulong intPart = BitConverter.ToUInt32(ntpData, serverReplyTime);

            //Get the seconds fraction
            ulong fractPart = BitConverter.ToUInt32(ntpData, serverReplyTime + 4);

            //Convert From big-endian to little-endian
            intPart = SwapEndianness(intPart);
            fractPart = SwapEndianness(fractPart);

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);

            //UTC time + 8 
            DateTime networkDateTime = (new DateTime(1900, 1, 1))
                .AddMilliseconds((long)milliseconds).AddHours(8);

            return networkDateTime;
        }

        // stackoverflow.com/a/3294698/162671
        static uint SwapEndianness(ulong x)
        {
            return (uint)(((x & 0x000000ff) << 24) +
                           ((x & 0x0000ff00) << 8) +
                           ((x & 0x00ff0000) >> 8) +
                           ((x & 0xff000000) >> 24));
        }
    }
}
