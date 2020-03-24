using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using Newtonsoft.Json;

namespace CYCU_Course_Selection_Helper.Models
{
    public static class HttpCommunication
    {
        private const string HostIp = "140.135.201.1";
        private static readonly string HostUrl = $"http://{HostIp}/";
        private static string _cookie = "";
        private static string _pageId = "";

        public static bool CheckServerConnect()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(HostIp, 5000);
                return pingReply != null && pingReply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool Init(out string secureRandom)
        {
            HttpWebResponse response = GrabResponse("/student/sso.srv", "cmd=login_init");
            if (response != null)
            {
                string getCookie = response.GetResponseHeader("Set-Cookie");
                if (!getCookie.Equals("")) _cookie = getCookie;     //  The cookie has not expired

                dynamic pairs = GetJsonObject(response);

                if (pairs["result"] == "True")
                {
                    secureRandom = pairs["secureRandom"];
                    return true;
                }

                secureRandom = "";
                return false;
            }

            secureRandom = "";
            return false;
        }

        public static bool Login(string id, string pw, out string msg)
        {
            var response = GrabResponse("/student/sso.srv", "cmd=login&userid=" + id + "&hash=" + pw);
            var pairs = GetJsonObject(response);

            msg = pairs.message;
            if (pairs["result"] == "True")
            {
                _pageId = pairs["pageId"];
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

        private static dynamic GetJsonObject(WebResponse inputResponse)
        {
            StreamReader reader = new StreamReader(inputResponse.GetResponseStream() ?? throw new InvalidOperationException());
            dynamic content = JsonConvert.DeserializeObject(reader.ReadToEnd());

            return content;
        }

        private static HttpWebResponse GrabResponse(string _dir, string _cmd)
        {
            try
            {
                string url = HostUrl + _dir;
                Uri uri = new Uri(url);

                //  Send Login Information
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "POST";
                request.Host = @"csys.cycu.edu.tw";
                request.KeepAlive = true;
                request.Headers.Add("Origin", "http://csys.cycu.edu.tw");
                request.Headers.Add("Page-Id", _pageId);
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

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
