using System;
using System.Collections;

namespace CYCU_Course_Selection_Helper
{
    public enum PROC_MODE { UNKNOWN = 0, REG = 303, SEL = 605 }
    public enum CONN_MODE { UNKNOWN = 0, OFFLINE = 1211, ONLINE = 109 }

    public class ProgramData
    {
        public static bool AcceptToConnect { get; set; }
        public static bool LoginSuccess { get; set; }
        public static string LoginID { get; set; }
        public static string LoginPW { get; set; }
        public static string EncryptPW { get; set; }

        public static string SecureRandom = null;

        public static ArrayList ReadyToSelectCoursesList = new ArrayList();

        public static ArrayList ReadyToDeleteCoursesList = new ArrayList();
        public static int CurrentSelectCourceIdx { get; set; }
        public static int CurrentDeleteCourceIdx { get; set; }
        public static bool OnScheduleEnabled { get; set; }
        public static DateTime CurrentNetworkTime { get; set; } 
    }
}
