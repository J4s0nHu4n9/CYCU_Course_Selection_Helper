/*
 *      Author : J4S0N.H
 *      Updates :
 *                  2020 / 03 / 24 - Refactor code
 *                  2018 / 03 / 05 - First release
 */

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using CYCU_Course_Selection_Helper.Models;
using CYCU_Course_Selection_Helper.SubForms;
using Timer = System.Timers.Timer;

namespace CYCU_Course_Selection_Helper
{
    public partial class MainForm : Form
    {
        private Timer _timerSyncNetworkTime;
        private Timer _timerWaitForScheduledTime;
        private Timer _timerCurrentTime;
        private Timer _timerLoopSelect;
        private Timer _timerLoopRegister;
        private Timer _timerLoopDelete;
        private Timer _timerTryToLogin;
        private Timer _timerKeepConnectAlive;

        private static ConnectionMode CMode { set; get; }

        public MainForm()
        {
            InitializeComponent();
            InitializeSystemTimer();
            InitializeCoursesList();
        }

        private static void InitializeCoursesList()
        {
            FileIo.LoadFileFromTxt("sel_courses.list", out ProgramData.ReadyToSelectCoursesList);
            FileIo.LoadFileFromTxt("del_courses.list", out ProgramData.ReadyToDeleteCoursesList);
        }

        private void InitializeSystemTimer()
        {
            //  Sync network time
            _timerSyncNetworkTime = new Timer
            {
                Interval = 5000
            };
            _timerSyncNetworkTime.Elapsed += timer_syncNetworkTime_Elapsed;

            //  Try to login
            _timerTryToLogin = new Timer
            {
                Interval = 1000
            };
            _timerTryToLogin.Elapsed += timer_tryToLogin_Elapsed;
            _timerTryToLogin.SynchronizingObject = this;

            //  Wait for scheduled time
            _timerWaitForScheduledTime = new Timer
            {
                Interval = 5000
            };
            _timerWaitForScheduledTime.Elapsed += timer_waitForScheduledTime_Elapsed;
            _timerWaitForScheduledTime.SynchronizingObject = this;

            //  Current time
            _timerCurrentTime = new Timer
            {
                Interval = 1000
            };
            _timerCurrentTime.Elapsed += timer_currentTime_Elapsed;
            _timerCurrentTime.SynchronizingObject = this;

            //  Register courses loop
            _timerLoopRegister = new Timer
            {
                Interval = 100 //  0.1 second
            };
            _timerLoopRegister.Elapsed += Timer_loopRegister_Elapsed;
            _timerLoopRegister.SynchronizingObject = this;

            //  Select courses loop
            _timerLoopSelect = new Timer
            {
                Interval = 200 //  0.2 second
            };
            _timerLoopSelect.Elapsed += Timer_loopSelect_Elapsed;
            _timerLoopSelect.SynchronizingObject = this;

            _timerLoopDelete = new Timer
            {
                Interval = 100
            };
            _timerLoopDelete.Elapsed += timer_loopDelete_Elapsed;
            _timerLoopDelete.SynchronizingObject = this;

            //  Keep connection alive
            _timerKeepConnectAlive = new Timer
            {
                Interval = 180000 //  180 second
            };
            _timerKeepConnectAlive.Elapsed += timer_keepConnectAlive_Elapsed;
            _timerKeepConnectAlive.SynchronizingObject = this;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //  To control whether send query or not
            ProgramData.AcceptToConnect = false;
            ProgramData.LoginSuccess = false;

            CMode = ConnectionMode.Unknown;

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
            _timerSyncNetworkTime.Start();
            _timerCurrentTime.Start();

            //  Keep connection alive timer start
            _timerKeepConnectAlive.Start();

            //  MainForm closing event (do logout)
            FormClosing += Main_FormClosing;

            //  For Debugger
            Debug.Print("Main(UI) thread : " + Thread.CurrentThread.ManagedThreadId);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CMode.Equals(ConnectionMode.Online))
                HttpCommunication.Logout(out string msg);
        }

        private void Btn_StartReg_Click(object sender, EventArgs e)
        {
            if (CheckSelCourseListCount() == 0)
                return;

            btn_readySelCoursesList.Enabled = false;
            radio_register.Enabled = radio_selection.Enabled = false;
            checkBox_OnSchedule.Enabled = group_TimePicker.Enabled = false;

            ProgramData.CurrentSelectCourseIdx = 0;
            _timerLoopRegister.Start();

            btn_StartReg.Enabled = false;
        }

        private void Btn_StartSel_Click(object sender, EventArgs e)
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
                    string scheduledTime = dateTimePicker_OnSchedule.Value.AddSeconds(-15)
                        .ToString("yyyy/MM/dd - HH:mm:ss");
                    AddLog("排程選課將於 " + scheduledTime + " 開始。");

                    _timerWaitForScheduledTime.Start();

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
            if (_timerWaitForScheduledTime.Enabled || _timerLoopSelect.Enabled)
            {
                _timerLoopSelect.Stop();
                _timerWaitForScheduledTime.Stop();

                AddLog("動作已取消。");

                _timerTryToLogin.Interval = 1000;

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

        private void ClearLog_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLog(null);
        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            if (ProgramData.AcceptToConnect) ExecuteLogin();
        }

        private void CancelLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timerTryToLogin.Stop();

            if (!ProgramData.LoginSuccess)
            {
                CMode = ConnectionMode.Unknown;
                slb_LoginAs.Text = "已取消登入";

                ProgramData.LoginSuccess = false;
                ProgramData.AcceptToConnect = false;

                //  Set Timer stop
                _timerLoopRegister.Stop();
                _timerLoopSelect.Stop();
                _timerWaitForScheduledTime.Stop();

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

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HttpCommunication.Logout(out string msg);

            AddLog(msg);
            CMode = ConnectionMode.Unknown;
            slb_LoginAs.Text = "尚未登入";

            ProgramData.LoginSuccess = false;
            ProgramData.AcceptToConnect = false;

            //  Set Timer stop
            _timerLoopRegister.Stop();
            _timerLoopSelect.Stop();
            _timerWaitForScheduledTime.Stop();

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

        private void Txt_Log_TextChanged(object sender, EventArgs e)
        {
            if (txt_Log.Lines.Length > 50) AddLog(null);

            txt_Log.SelectionStart = txt_Log.Text.Length;
            txt_Log.ScrollToCaret();
        }

        private void Txt_Log_Enter(object sender, EventArgs e)
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
                txt_Log.Text += $"{currentTime}\t{msg}{Environment.NewLine}";
            }
        }

        private int CheckSelCourseListCount()
        {
            int count = ProgramData.ReadyToSelectCoursesList.Count;
            if (count == 0) AddLog("請先將待選課程加入課程代碼清單。");

            return count;
        }

        private int CheckDelCourseListCount()
        {
            int count = ProgramData.ReadyToDeleteCoursesList.Count;
            if (count == 0) AddLog("請先將待退課程加入課程代碼清單。");

            return count;
        }

        private void ExecuteSelect()
        {
            if (!ProgramData.LoginSuccess) AddLog("等待登入成功後將自動進行嘗試加選。");

            if (checkBox_DelCourseFirst.Checked)
                if (CheckDelCourseListCount() > 0)
                {
                    ProgramData.CurrentDeleteCourseIdx = 0;
                    _timerLoopDelete.Start();
                }

            ProgramData.CurrentSelectCourseIdx = 0;
            _timerLoopSelect.Start();

            btn_StartSel.Visible = false;
            btn_Cancel.Visible = true;
        }

        private void ExecuteLogin()
        {
            _timerTryToLogin.Start();

            loginToolStripMenuItem.Visible = false;
            cancelLoginToolStripMenuItem.Visible = true;
        }

        private void LostConnect()
        {
            Debug.Print(DateTime.Now.ToLongTimeString() + " - Already lost connection.");

            CMode = ConnectionMode.Offline;

            ProgramData.LoginSuccess = false;

            logoutToolStripMenuItem.Visible = false;
            myCourseToolStripMenuItem.Visible = false;
            searchCourseToolStripMenuItem.Visible = false;
            ExecuteLogin();
        }


        /*  Checked changed events  */
        private void Radio_register_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_register.Checked)
            {
                btn_StartSel.Visible = false;
                btn_StartReg.Visible = true;

                if (!ProgramData.LoginSuccess || CMode.Equals(ConnectionMode.Offline))
                {
                    AddLog("必須登入成功才能選擇篩選登記模式。");
                    btn_StartReg.Enabled = false;
                }
                else
                {
                    btn_StartReg.Enabled = true;
                }

                btn_readySelCoursesList.Enabled = true;
                checkBox_DelCourseFirst.Enabled = false;
                checkBox_OnHook.Enabled = false;
                checkBox_OnSchedule.Enabled = false;
                group_TimePicker.Enabled = false;
            }
        }

        private void Radio_selection_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_selection.Checked)
            {
                btn_StartReg.Visible = false;
                btn_StartSel.Visible = true;

                btn_readySelCoursesList.Enabled = true;
                checkBox_OnHook.Enabled = true;
                checkBox_OnSchedule.Enabled = true;
                group_TimePicker.Enabled = checkBox_OnSchedule.Checked;
                checkBox_DelCourseFirst.Enabled = true;
                btn_readyDelCoursesList.Enabled = checkBox_DelCourseFirst.Checked;
            }
        }

        private void CheckBox_OnHook_CheckedChanged(object sender, EventArgs e)
        {
            _timerLoopSelect.Interval = checkBox_OnHook.Checked ? 500 : 200;
            AddLog("時間間隔更改為 " + _timerLoopSelect.Interval + " 毫秒。");
        }

        private void CheckBox_OnSchedule_CheckedChanged(object sender, EventArgs e)
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

        private void CheckBox_DelCourseFirst_CheckedChanged(object sender, EventArgs e)
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
        private void Timer_loopRegister_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
                if (radio_register.Checked)
                {
                    string opcode = ProgramData.ReadyToSelectCoursesList[ProgramData.CurrentSelectCourseIdx].ToString();

                    HttpCommunication.AddRegister(opcode, out string msg);

                    if (ProgramData.CurrentSelectCourseIdx + 1 == ProgramData.ReadyToSelectCoursesList.Count)
                    {
                        _timerLoopRegister.Stop();

                        btn_readySelCoursesList.Enabled = true;
                        radio_register.Enabled = radio_selection.Enabled = true;
                        checkBox_OnSchedule.Enabled = true;
                        group_TimePicker.Enabled = checkBox_OnSchedule.Checked;

                        btn_StartReg.Enabled = true;
                    }
                    else
                    {
                        ProgramData.CurrentSelectCourseIdx += 1;
                    }

                    AddLog(msg);
                }
        }

        private void Timer_loopSelect_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
                if (radio_selection.Checked)
                {
                    string opcode = ProgramData.ReadyToSelectCoursesList[ProgramData.CurrentSelectCourseIdx].ToString();

                    if (HttpCommunication.AddSelection(opcode, out string msg))
                    {
                        ProgramData.ReadyToSelectCoursesList.Remove(ProgramData.CurrentSelectCourseIdx);
                        ProgramData.CurrentSelectCourseIdx -= 1;
                    }

                    if (ProgramData.ReadyToSelectCoursesList.Count == 0)
                    {
                        _timerLoopSelect.Stop();
                        AddLog("全部加選完畢。");

                        btn_readySelCoursesList.Enabled = true;
                        radio_register.Enabled = radio_selection.Enabled = true;
                        checkBox_OnSchedule.Enabled = true;
                        group_TimePicker.Enabled = checkBox_OnSchedule.Checked;

                        btn_Cancel.Visible = false;
                        btn_StartSel.Visible = true;
                    }
                    else if (ProgramData.CurrentSelectCourseIdx + 1 == ProgramData.ReadyToSelectCoursesList.Count)
                    {
                        ProgramData.CurrentSelectCourseIdx = 0; //  If reach end of list, return to start of list
                    }
                    else
                    {
                        ProgramData.CurrentSelectCourseIdx += 1; //  Default, retrieve list one by one
                    }

                    if (msg.Contains("未知")) //  If lost connect
                    {
                        AddLog("等待登入成功後將自動進行嘗試加選。");
                        LostConnect();
                    }
                    else
                    {
                        AddLog(msg); //  Normal status
                    }
                }
        }

        private void timer_loopDelete_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
                if (checkBox_DelCourseFirst.Checked)
                {
                    string opCode = ProgramData.ReadyToDeleteCoursesList[ProgramData.CurrentDeleteCourseIdx].ToString();

                    HttpCommunication.DeleteSelection(opCode, out string msg);

                    if (ProgramData.CurrentDeleteCourseIdx + 1 == ProgramData.ReadyToDeleteCoursesList.Count)
                        _timerLoopDelete.Stop();
                    else ProgramData.CurrentDeleteCourseIdx += 1;

                    AddLog(msg);
                }
        }

        private void timer_tryToLogin_Elapsed(object sender, EventArgs e)
        {
            Debug.Print(DateTime.Now.ToLongTimeString() + " - Trying to login");

            if (!HttpCommunication.Init(out ProgramData.SecureRandom))
            {
                if (CMode.Equals(ConnectionMode.Unknown))
                {
                    CMode = ConnectionMode.Offline;
                    radio_register.Enabled = radio_selection.Enabled = true;
                    radio_selection.Checked = true;
                }
                else if (CMode.Equals(ConnectionMode.Offline))
                {
                    slb_LoginAs.Text = "嘗試連接到伺服器（離線模式）";
                }
            }
            else
            {
                slb_LoginAs.Text = "伺服器連線成功，嘗試登入使用者";
                CMode = ConnectionMode.Online;
            }

            if (CMode.Equals(ConnectionMode.Online))
            {
                ProgramData.EncryptPw =
                    Crypto.GetEncrypt(ProgramData.LoginPw, ProgramData.LoginId, ProgramData.SecureRandom);
                if (!HttpCommunication.Login(ProgramData.LoginId, ProgramData.EncryptPw, out string msg))
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
                    slb_LoginAs.Text = "登入為 " + ProgramData.LoginId;
                    ProgramData.LoginSuccess = true;

                    loginToolStripMenuItem.Visible = false;
                    cancelLoginToolStripMenuItem.Visible = false;

                    logoutToolStripMenuItem.Visible = true;
                    myCourseToolStripMenuItem.Visible = true;
                    searchCourseToolStripMenuItem.Visible = true;

                    if (!_timerLoopSelect.Enabled)
                    {
                        radio_register.Enabled = radio_selection.Enabled = true;
                        radio_register.Checked = true;
                    }
                }

                _timerTryToLogin.Stop();
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
                DateTime gottonNetworkTime = NtpClient.GetNetworkTime();

                //  Success get Network time, assign to ProgramData.CurrentNetworkTime
                ProgramData.CurrentNetworkTime = gottonNetworkTime;

                //  Sync network time per 5 mins
                _timerSyncNetworkTime.Interval = 300000;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);

                //  Sync fail, try again after 5 seconds later
                _timerSyncNetworkTime.Interval = 5000;
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
                _timerTryToLogin.Interval = 300;
                ExecuteSelect();
                _timerWaitForScheduledTime.Stop();
            }
        }

        private void timer_keepConnectAlive_Elapsed(object sender, EventArgs e)
        {
            if (ProgramData.LoginSuccess)
                //  If action not finish yet, do not block network source.
                if (!(_timerLoopRegister.Enabled || _timerLoopSelect.Enabled))
                {
                    if (!HttpCommunication.GetAllMyCourses(ProgramData.LoginId, out _, out _))
                    {
                        AddLog("已由伺服器端離線。");
                        LostConnect();
                    }
                    else
                    {
                        Debug.Print(DateTime.Now.ToLongTimeString() + " - Keep connection alive.");
                    }
                }
        }
    }
}
