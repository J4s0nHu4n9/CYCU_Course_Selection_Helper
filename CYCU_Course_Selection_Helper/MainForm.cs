/*
 *      Author : J4S0N.H
 *      Last Update : 2018 / 03 / 05
 */

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CYCU_Course_Selection_Helper
{
    public partial class MainForm : Form
    {
        public System.Timers.Timer timer_syncNetworkTime;
        public System.Timers.Timer timer_waitForScheduledTime;
        public System.Timers.Timer timer_currentTime;
        public System.Timers.Timer timer_loopSelect;
        public System.Timers.Timer timer_loopRegister;
        public System.Timers.Timer timer_loopDelete;
        public System.Timers.Timer timer_tryToLogin;
        public System.Timers.Timer timer_keepConnectAlive;

        public static PROC_MODE ProcessMode { set; get; }
        public static CONN_MODE ConnectMode { set; get; }

        public MainForm()
        {
            InitializeComponent();
            InitializeSystemTimer();
            InitializeCoursesList();
        }

        private void InitializeCoursesList()
        {
            FileIO.LoadFileFromTxt("sel_courses.list", out ProgramData.ReadyToSelectCoursesList);
            FileIO.LoadFileFromTxt("del_courses.list", out ProgramData.ReadyToDeleteCoursesList);
        }

        private void InitializeSystemTimer()
        {
            //  Sync network time
            timer_syncNetworkTime = new System.Timers.Timer
            {
                Interval = 5000
            };
            timer_syncNetworkTime.Elapsed += timer_syncNetworkTime_Elapsed;

            //  Try to login
            timer_tryToLogin = new System.Timers.Timer
            {
                Interval = 1000
            };
            timer_tryToLogin.Elapsed += timer_tryToLogin_Elapsed;
            timer_tryToLogin.SynchronizingObject = this;

            //  Wait for scheduled time
            timer_waitForScheduledTime = new System.Timers.Timer
            {
                Interval = 5000
            };
            timer_waitForScheduledTime.Elapsed += timer_waitForScheduledTime_Elapsed;
            timer_waitForScheduledTime.SynchronizingObject = this;

            //  Current time
            timer_currentTime = new System.Timers.Timer
            {
                Interval = 1000
            };
            timer_currentTime.Elapsed += timer_currentTime_Elapsed;
            timer_currentTime.SynchronizingObject = this;

            //  Register courses looper
            timer_loopRegister = new System.Timers.Timer
            {
                Interval = 100     //  0.1 second
            };
            timer_loopRegister.Elapsed += timer_loopRegister_Elapsed;
            timer_loopRegister.SynchronizingObject = this;

            //  Select courses looper
            timer_loopSelect = new System.Timers.Timer
            {
                Interval = 200      //  0.2 second
            };
            timer_loopSelect.Elapsed += timer_loopSelect_Elapsed;
            timer_loopSelect.SynchronizingObject = this;

            timer_loopDelete = new System.Timers.Timer
            {
                Interval = 100
            };
            timer_loopDelete.Elapsed += timer_loopDelete_Elapsed;
            timer_loopDelete.SynchronizingObject = this;

            //  Keep connection alive
            timer_keepConnectAlive = new System.Timers.Timer
            {
                Interval = 180000   //  180 second
            };
            timer_keepConnectAlive.Elapsed += timer_keepConnectAlive_Elapsed;
            timer_keepConnectAlive.SynchronizingObject = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //  To control wheather send query or not
            ProgramData.AcceptToConnect = false;
            ProgramData.LoginSuccess = false;

            ConnectMode = CONN_MODE.UNKNOWN;

            slb_LoginAs.Visible = true;
            slb_LoginAs.Text = "尚未登入";

            //  Try to check connection
            if (!HttpCommunication.CheckServerConnect())
            {
                AddLog("無法建立與選課伺服器的連接，請檢查連線。");
                loginToolStripMenuItem.Enabled = false;
            }

            //  Default visible
            btn_StartReg.Visible = true;
            btn_StartSel.Visible = btn_Cancel.Visible = false;

            //  Default enabled
            btn_StartReg.Enabled = false;
            radio_register.Enabled = radio_selection.Enabled = false;
            btn_readySelCoursesList.Enabled = true;
            btn_readyDelCoursesList.Enabled = false;
            checkBox_OnSchedule.Enabled = false;
            group_TimePicker.Enabled = false;

            //  Default checked
            checkBox_OnHook.Checked = true;

            //  Default value
            ProgramData.CurrentNetworkTime = DateTime.Now;
            dateTimePicker_OnSchedule.Value = ProgramData.CurrentNetworkTime;

            //  Time timers start
            timer_syncNetworkTime.Start();
            timer_currentTime.Start();

            //  Keep connection alive timer start
            timer_keepConnectAlive.Start();

            //  MainForm closing event (do logout)
            FormClosing += new FormClosingEventHandler(Main_FormClosing);

            //  For Debugger
            Debug.Print("Main(UI) thread : " + Thread.CurrentThread.ManagedThreadId);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConnectMode.Equals(CONN_MODE.ONLINE))
                HttpCommunication.Logout(out string msg);
        }

        private void btn_StartReg_Click(object sender, EventArgs e)
        {
            if (CheckSelCourseListCount() == 0)
                return;

            btn_readySelCoursesList.Enabled = false;
            radio_register.Enabled = radio_selection.Enabled = false;
            checkBox_OnSchedule.Enabled = group_TimePicker.Enabled = false;

            ProgramData.CurrentSelectCourceIdx = 0;
            timer_loopRegister.Start();

            btn_StartReg.Enabled = false;
        }

        private void btn_StartSel_Click(object sender, EventArgs e)
        {
            if (CheckSelCourseListCount() == 0)
                return;

            btn_readySelCoursesList.Enabled = false;
            radio_register.Enabled = radio_selection.Enabled = false;
            checkBox_OnSchedule.Enabled = group_TimePicker.Enabled = false;
            checkBox_DelCourseFirst.Enabled = btn_readyDelCoursesList.Enabled = false;

            if (ProgramData.OnScheduleEnabled)
            {
                if (dateTimePicker_OnSchedule.Value.AddSeconds(-30) > ProgramData.CurrentNetworkTime)
                {
                    string scheduledTime = dateTimePicker_OnSchedule.Value.AddSeconds(-15).ToString("yyyy/MM/dd - HH:mm:ss");
                    AddLog("排程選課將於 " + scheduledTime + " 開始。");

                    timer_waitForScheduledTime.Start();

                    btn_StartSel.Visible = false;
                    btn_Cancel.Visible = true;
                }
                else
                {
                    AddLog("排程時間必須至少大於當前時間 30 秒。");

                    btn_readySelCoursesList.Enabled = true;
                    radio_register.Enabled = radio_selection.Enabled = true;
                    checkBox_OnSchedule.Enabled = true;
                    group_TimePicker.Enabled = checkBox_OnSchedule.Checked;
                    checkBox_DelCourseFirst.Enabled = true;
                    btn_readyDelCoursesList.Enabled = checkBox_DelCourseFirst.Checked;

                    btn_Cancel.Visible = false;
                    btn_StartSel.Visible = true;
                }
            }
            else
            {
                ExecuteSelect();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (timer_waitForScheduledTime.Enabled || timer_loopSelect.Enabled)
            {
                timer_loopSelect.Stop();
                timer_waitForScheduledTime.Stop();

                AddLog("動作已取消。");

                timer_tryToLogin.Interval = 1000;

                btn_readySelCoursesList.Enabled = true;
                radio_register.Enabled = radio_selection.Enabled = true;
                checkBox_OnSchedule.Enabled = true;
                group_TimePicker.Enabled = checkBox_OnSchedule.Checked;
                checkBox_DelCourseFirst.Enabled = true;
                btn_readyDelCoursesList.Enabled = checkBox_DelCourseFirst.Checked;

                btn_Cancel.Visible = false;
                btn_StartSel.Visible = true;
            }
        }

        private void btn_readySelCoursesList_Click(object sender, EventArgs e)
        {
            AddCourse courses = new AddCourse();
            courses.ShowDialog();
        }

        private void btn_readyDelCoursesList_Click(object sender, EventArgs e)
        {
            DelCourse courses = new DelCourse();
            courses.ShowDialog();
        }

        private void searchCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseStudentsQuery courseStudentsQuery = new CourseStudentsQuery();
            courseStudentsQuery.ShowDialog();
        }

        private void clearLog_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLog(null);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            if (ProgramData.AcceptToConnect)
            {
                ExecuteLogin();
            }
        }

        private void cancelLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer_tryToLogin.Stop();

            if (!ProgramData.LoginSuccess)
            {
                ConnectMode = CONN_MODE.UNKNOWN;
                slb_LoginAs.Text = "已取消登入";

                ProgramData.LoginSuccess = false;
                ProgramData.AcceptToConnect = false;

                //  Set Timer stop
                timer_loopRegister.Stop();
                timer_loopSelect.Stop();
                timer_waitForScheduledTime.Stop();

                //  Set Visible
                loginToolStripMenuItem.Visible = true;
                cancelLoginToolStripMenuItem.Visible = false;

                btn_StartReg.Visible = true;
                btn_StartSel.Visible = btn_Cancel.Visible = false;

                //  Set Enabled
                btn_StartReg.Enabled = false;
                radio_register.Enabled = radio_selection.Enabled = false;
                btn_readySelCoursesList.Enabled = true;
                checkBox_OnHook.Enabled = checkBox_OnSchedule.Enabled = checkBox_DelCourseFirst.Enabled = false;
                group_TimePicker.Enabled = false;

                //  Set Checked
                radio_register.Checked = radio_selection.Checked = false;
                checkBox_OnSchedule.Checked = false;
                checkBox_DelCourseFirst.Checked = false;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpCommunication.Logout(out string msg);

            AddLog(msg);
            ConnectMode = CONN_MODE.UNKNOWN;
            slb_LoginAs.Text = "尚未登入";

            ProgramData.LoginSuccess = false;
            ProgramData.AcceptToConnect = false;

            //  Set Timer stop
            timer_loopRegister.Stop();
            timer_loopSelect.Stop();
            timer_waitForScheduledTime.Stop();

            //  Set Visible
            loginToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = false;
            myCourseToolStripMenuItem.Visible = false;
            searchCourseToolStripMenuItem.Visible = false;

            btn_StartReg.Visible = true;
            btn_StartSel.Visible = btn_Cancel.Visible = false;

            //  Set Enabled
            btn_StartReg.Enabled = false;
            radio_register.Enabled = radio_selection.Enabled = false;
            btn_readySelCoursesList.Enabled = true;
            checkBox_OnHook.Enabled = checkBox_OnSchedule.Enabled = checkBox_DelCourseFirst.Enabled = false;
            group_TimePicker.Enabled = false;

            //  Set Checked
            radio_register.Checked = radio_selection.Checked = false;
            checkBox_OnSchedule.Checked = false;
            checkBox_DelCourseFirst.Checked = false;
        }

        private void txt_Log_TextChanged(object sender, EventArgs e)
        {
            if (txt_Log.Lines.Length > 50) AddLog(null);

            txt_Log.SelectionStart = txt_Log.Text.Length;
            txt_Log.ScrollToCaret();
        }

        private void txt_Log_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void myCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyCourse myCourse = new MyCourse();
            myCourse.ShowDialog();
        }

        private void AddLog(string msg)
        {
            if (msg == null)
            {
                txt_Log.Text = "";
            }
            else
            {
                string currentTime = ProgramData.CurrentNetworkTime.ToString("HH:mm:ss");
                txt_Log.Text += currentTime + "\t" + msg + "\r\n";
            }
        }

        private int CheckSelCourseListCount()
        {
            int count = ProgramData.ReadyToSelectCoursesList.Count;
            if (count == 0)
            {
                AddLog("請先將待選課程加入課程代碼清單。");
            }
            return count;
        }

        private int CheckDelCourseListCount()
        {
            int count = ProgramData.ReadyToDeleteCoursesList.Count;
            if (count == 0)
            {
                AddLog("請先將待退課程加入課程代碼清單。");
            }
            return count;
        }

        private void ExecuteSelect()
        {
            if (!ProgramData.LoginSuccess) AddLog("等待登入成功後將自動進行嘗試加選。");

            if (checkBox_DelCourseFirst.Checked)
            {
                if (CheckDelCourseListCount() > 0)
                {
                    ProgramData.CurrentDeleteCourceIdx = 0;
                    timer_loopDelete.Start();
                }
            }

            ProgramData.CurrentSelectCourceIdx = 0;
            timer_loopSelect.Start();

            btn_StartSel.Visible = false;
            btn_Cancel.Visible = true;
        }

        private void ExecuteLogin()
        {
            timer_tryToLogin.Start();

            loginToolStripMenuItem.Visible = false;
            cancelLoginToolStripMenuItem.Visible = true;
        }

        private void LostConnect()
        {
            Debug.Print(DateTime.Now.ToLongTimeString() + " - Already lost connection.");

            ConnectMode = CONN_MODE.OFFLINE;

            ProgramData.LoginSuccess = false;
            
            logoutToolStripMenuItem.Visible = false;
            myCourseToolStripMenuItem.Visible = false;
            searchCourseToolStripMenuItem.Visible = false;
            ExecuteLogin();
        }



        /*  Checked changed events  */
        private void radio_register_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_register.Checked)
            {
                btn_StartSel.Visible = false;
                btn_StartReg.Visible = true;

                if (!ProgramData.LoginSuccess || ConnectMode.Equals(CONN_MODE.OFFLINE))
                {
                    AddLog("必須登入成功才能選擇篩選登記模式。");
                    btn_StartReg.Enabled = false;
                }
                else
                {
                    btn_StartReg.Enabled = true;
                }

                ProcessMode = PROC_MODE.REG;

                btn_readySelCoursesList.Enabled = true;
                checkBox_DelCourseFirst.Enabled = false;
                checkBox_OnHook.Enabled = false;
                checkBox_OnSchedule.Enabled = false;
                group_TimePicker.Enabled = false;
            }
        }

        private void radio_selection_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_selection.Checked)
            {
                btn_StartReg.Visible = false;
                btn_StartSel.Visible = true;

                ProcessMode = PROC_MODE.SEL;

                btn_readySelCoursesList.Enabled = true;
                checkBox_OnHook.Enabled = true;
                checkBox_OnSchedule.Enabled = true;
                group_TimePicker.Enabled = checkBox_OnSchedule.Checked;
                checkBox_DelCourseFirst.Enabled = true;
                btn_readyDelCoursesList.Enabled = checkBox_DelCourseFirst.Checked;

            }
        }

        private void checkBox_OnHook_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OnHook.Checked)
            {
                timer_loopSelect.Interval = 500;
            }
            else
            {
                timer_loopSelect.Interval = 200;
            }
            AddLog("時間間隔更改為 " + timer_loopSelect.Interval + " 毫秒。");
        }

        private void checkBox_OnSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_OnSchedule.Checked)
            {
                dateTimePicker_OnSchedule.Value = ProgramData.CurrentNetworkTime;
                group_TimePicker.Enabled = true;
                ProgramData.OnScheduleEnabled = true;
                AddLog("啟用排程選課，請選擇加退選日期及時間。");
            }
            else
            {
                group_TimePicker.Enabled = false;
                ProgramData.OnScheduleEnabled = false;
                AddLog("已停用排程選課。");
            }
        }

        private void checkBox_DelCourseFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_DelCourseFirst.Checked)
            {
                AddLog("已啟用加選前先退選模式，請將要退的課程加入待退清單中。(注意：此模式退選將不會詢問是否退選，請加入確定要退選的課程)");
                btn_readyDelCoursesList.Enabled = true;
            }
            else
            {
                AddLog("已停用加選前先退選模式。");
                btn_readyDelCoursesList.Enabled = false;
            }
        }



        /*  Timer elapsed definitions  */
        private void timer_loopRegister_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
            {
                if (radio_register.Checked)
                {
                    string opcode = ProgramData.ReadyToSelectCoursesList[ProgramData.CurrentSelectCourceIdx].ToString();

                    HttpCommunication.AddRegister(opcode, out string msg);

                    if (ProgramData.CurrentSelectCourceIdx + 1 == ProgramData.ReadyToSelectCoursesList.Count)
                    {
                        timer_loopRegister.Stop();

                        btn_readySelCoursesList.Enabled = true;
                        radio_register.Enabled = radio_selection.Enabled = true;
                        checkBox_OnSchedule.Enabled = true;
                        group_TimePicker.Enabled = checkBox_OnSchedule.Checked;

                        btn_StartReg.Enabled = true;
                    }
                    else ProgramData.CurrentSelectCourceIdx += 1;

                    AddLog(msg);
                }
            }
        }

        private void timer_loopSelect_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
            {
                if (radio_selection.Checked)
                {
                    string opcode = ProgramData.ReadyToSelectCoursesList[ProgramData.CurrentSelectCourceIdx].ToString();

                    if (HttpCommunication.AddSelection(opcode, out string msg))
                    {
                        ProgramData.ReadyToSelectCoursesList.Remove(ProgramData.CurrentSelectCourceIdx);
                        ProgramData.CurrentSelectCourceIdx -= 1;
                    }

                    if (ProgramData.ReadyToSelectCoursesList.Count == 0)
                    {
                        timer_loopSelect.Stop();
                        AddLog("全部加選完畢。");

                        btn_readySelCoursesList.Enabled = true;
                        radio_register.Enabled = radio_selection.Enabled = true;
                        checkBox_OnSchedule.Enabled = true;
                        group_TimePicker.Enabled = checkBox_OnSchedule.Checked;

                        btn_Cancel.Visible = false;
                        btn_StartSel.Visible = true;
                    }
                    else if (ProgramData.CurrentSelectCourceIdx + 1 == ProgramData.ReadyToSelectCoursesList.Count)
                        ProgramData.CurrentSelectCourceIdx = 0;       //  If reach end of list, return to start of list
                    else
                        ProgramData.CurrentSelectCourceIdx += 1;      //  Default, retrieve list one by one

                    if (msg.Contains("未知"))     //  If lost connect
                    {
                        AddLog("等待登入成功後將自動進行嘗試加選。");
                        LostConnect();
                    }
                    else AddLog(msg);           //  Normal status
                }
            }
        }

        private void timer_loopDelete_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
            {
                if (checkBox_DelCourseFirst.Checked)
                {
                    string opcode = ProgramData.ReadyToDeleteCoursesList[ProgramData.CurrentDeleteCourceIdx].ToString();

                    HttpCommunication.DeleteSelection(opcode, out string msg);

                    if (ProgramData.CurrentDeleteCourceIdx + 1 == ProgramData.ReadyToDeleteCoursesList.Count)
                    {
                        timer_loopDelete.Stop();
                    }
                    else ProgramData.CurrentDeleteCourceIdx += 1;

                    AddLog(msg);
                }
            }
        }

        private void timer_tryToLogin_Elapsed(object sender, EventArgs e)
        {
            Debug.Print(DateTime.Now.ToLongTimeString() + " - Trying to login");

            if (!HttpCommunication.Init(out ProgramData.SecureRandom))
            {
                if (ConnectMode.Equals(CONN_MODE.UNKNOWN))
                {
                    ConnectMode = CONN_MODE.OFFLINE;
                    radio_register.Enabled = radio_selection.Enabled = true;
                    radio_selection.Checked = true;
                }
                else if (ConnectMode.Equals(CONN_MODE.OFFLINE))
                {
                    slb_LoginAs.Text = "嘗試連接到伺服器（離線模式）";
                }
            }
            else
            {
                slb_LoginAs.Text = "伺服器連線成功，嘗試登入使用者";
                ConnectMode = CONN_MODE.ONLINE;
            }

            if (ConnectMode.Equals(CONN_MODE.ONLINE))
            {
                ProgramData.EncryptPW = Crypto.GetEncrypt(ProgramData.LoginPW, ProgramData.LoginID, ProgramData.SecureRandom);
                if (!HttpCommunication.Login(ProgramData.LoginID, ProgramData.EncryptPW, out string msg))
                {
                    AddLog(msg);
                    ProgramData.LoginSuccess = false;
                    slb_LoginAs.Text = "登入失敗";

                    loginToolStripMenuItem.Visible = true;
                    cancelLoginToolStripMenuItem.Visible = false;
                }
                else
                {
                    AddLog(msg);
                    slb_LoginAs.Text = "登入為 " + ProgramData.LoginID;
                    ProgramData.LoginSuccess = true;

                    loginToolStripMenuItem.Visible = false;
                    cancelLoginToolStripMenuItem.Visible = false;

                    logoutToolStripMenuItem.Visible = true;
                    myCourseToolStripMenuItem.Visible = true;
                    searchCourseToolStripMenuItem.Visible = true;

                    if (!timer_loopSelect.Enabled)
                    {
                        radio_register.Enabled = radio_selection.Enabled = true;
                        radio_register.Checked = true;
                    }
                }

                timer_tryToLogin.Stop();
            }
        }

        private void timer_currentTime_Elapsed(object sender, EventArgs e)
        {
            ProgramData.CurrentNetworkTime = ProgramData.CurrentNetworkTime.AddSeconds(1);
            lb_currentTime.Text = ProgramData.CurrentNetworkTime.ToString("yyyy/MM/dd - HH:mm:ss");
        }

        private void timer_syncNetworkTime_Elapsed(object sender, EventArgs e)
        {
            try
            {
                var gottonNetworkTime = NTPClient.GetNetworkTime();

                //  Success get Network time, assign to ProgramData.CurrentNetworkTime
                ProgramData.CurrentNetworkTime = gottonNetworkTime;

                //  Sync network time per 5 mins
                timer_syncNetworkTime.Interval = 300000;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);

                //  Sync fail, try again after 5 seconds later
                timer_syncNetworkTime.Interval = 5000;
            }
            finally
            {
                //  For Debugger
                Debug.Print(DateTime.Now.ToLongTimeString() + "- Sync network time.");
            }
        }

        private void timer_waitForScheduledTime_Elapsed(object sender, EventArgs e)
        {
            Debug.Print(DateTime.Now.ToLongTimeString() + " - Still wait for scheduled time.");

            if (ProgramData.CurrentNetworkTime >= dateTimePicker_OnSchedule.Value.AddSeconds(-15))
            {
                timer_tryToLogin.Interval = 300;
                ExecuteSelect();
                timer_waitForScheduledTime.Stop();
            }
        }

        private void timer_keepConnectAlive_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
            {
                //  If action not finish yet, dont block network source.
                if (!(timer_loopRegister.Enabled || timer_loopSelect.Enabled))
                {
                    if (!HttpCommunication.GetAllMyCourses(ProgramData.LoginID, out dynamic datas, out string msg))
                    {
                        AddLog("已由伺服器端離線。");
                        LostConnect();
                    }
                    else Debug.Print(DateTime.Now.ToLongTimeString() + " - Keep connection alive.");
                }
            }
        }
    }
}
