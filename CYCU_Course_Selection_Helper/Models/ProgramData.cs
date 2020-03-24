using System;
using System.Collections;

namespace CYCU_Course_Selection_Helper.Models
{
    public enum ProcessMode { Unknown = 0, Register = 303, Selection = 605 }
    public enum ConnectionMode { Unknown = 0, Offline = 1211, Online = 109 }

    public static class ProgramData
    {
        public static bool AcceptToConnect { get; set; }
        public static bool LoginSuccess { get; set; }
        public static string LoginId { get; set; }
        public static string LoginPw { get; set; }
        public static string EncryptPw { get; set; }

        public static string SecureRandom = null;

        public static ArrayList ReadyToSelectCoursesList = new ArrayList();

        public static ArrayList ReadyToDeleteCoursesList = new ArrayList();
        public static int CurrentSelectCourseIdx { get; set; }
        public static int CurrentDeleteCourseIdx { get; set; }
        public static bool OnScheduleEnabled { get; set; }
        public static DateTime CurrentNetworkTime { get; set; } 
    }
}
