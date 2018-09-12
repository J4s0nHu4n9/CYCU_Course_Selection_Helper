namespace CYCU_Course_Selection_Helper
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txt_Log = new System.Windows.Forms.TextBox();
            this.cmenu_txtLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLog_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.slb_LoginAs = new System.Windows.Forms.ToolStripStatusLabel();
            this.radio_register = new System.Windows.Forms.RadioButton();
            this.radio_selection = new System.Windows.Forms.RadioButton();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_readySelCoursesList = new System.Windows.Forms.Button();
            this.checkBox_OnHook = new System.Windows.Forms.CheckBox();
            this.checkBox_OnSchedule = new System.Windows.Forms.CheckBox();
            this.group_TimePicker = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_OnSchedule = new System.Windows.Forms.DateTimePicker();
            this.lb_currentTime = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.searchCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_StartReg = new System.Windows.Forms.Button();
            this.btn_StartSel = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.checkBox_DelCourseFirst = new System.Windows.Forms.CheckBox();
            this.btn_readyDelCoursesList = new System.Windows.Forms.Button();
            this.cmenu_txtLog.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.group_TimePicker.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Log
            // 
            this.txt_Log.BackColor = System.Drawing.Color.Black;
            this.txt_Log.ContextMenuStrip = this.cmenu_txtLog;
            this.txt_Log.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txt_Log.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txt_Log.ForeColor = System.Drawing.Color.Lime;
            this.txt_Log.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txt_Log.Location = new System.Drawing.Point(12, 28);
            this.txt_Log.Multiline = true;
            this.txt_Log.Name = "txt_Log";
            this.txt_Log.ReadOnly = true;
            this.txt_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Log.Size = new System.Drawing.Size(300, 307);
            this.txt_Log.TabIndex = 3;
            this.txt_Log.Text = "00:00:00\t請先進行登入。\r\n";
            this.txt_Log.TextChanged += new System.EventHandler(this.txt_Log_TextChanged);
            this.txt_Log.Enter += new System.EventHandler(this.txt_Log_Enter);
            // 
            // cmenu_txtLog
            // 
            this.cmenu_txtLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLog_ToolStripMenuItem});
            this.cmenu_txtLog.Name = "cmenu_txtLog";
            this.cmenu_txtLog.Size = new System.Drawing.Size(123, 26);
            // 
            // clearLog_ToolStripMenuItem
            // 
            this.clearLog_ToolStripMenuItem.Name = "clearLog_ToolStripMenuItem";
            this.clearLog_ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearLog_ToolStripMenuItem.Text = "清空紀錄";
            this.clearLog_ToolStripMenuItem.Click += new System.EventHandler(this.clearLog_ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slb_LoginAs});
            this.statusStrip.Location = new System.Drawing.Point(0, 385);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(465, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip";
            // 
            // slb_LoginAs
            // 
            this.slb_LoginAs.Name = "slb_LoginAs";
            this.slb_LoginAs.Size = new System.Drawing.Size(49, 17);
            this.slb_LoginAs.Text = "loginAs";
            this.slb_LoginAs.Visible = false;
            // 
            // radio_register
            // 
            this.radio_register.AutoSize = true;
            this.radio_register.Location = new System.Drawing.Point(16, 341);
            this.radio_register.Name = "radio_register";
            this.radio_register.Size = new System.Drawing.Size(71, 16);
            this.radio_register.TabIndex = 6;
            this.radio_register.Text = "篩選登記";
            this.radio_register.UseVisualStyleBackColor = true;
            this.radio_register.CheckedChanged += new System.EventHandler(this.radio_register_CheckedChanged);
            // 
            // radio_selection
            // 
            this.radio_selection.AutoSize = true;
            this.radio_selection.Location = new System.Drawing.Point(16, 362);
            this.radio_selection.Name = "radio_selection";
            this.radio_selection.Size = new System.Drawing.Size(47, 16);
            this.radio_selection.TabIndex = 7;
            this.radio_selection.Text = "加選";
            this.radio_selection.UseVisualStyleBackColor = true;
            this.radio_selection.CheckedChanged += new System.EventHandler(this.radio_selection_CheckedChanged);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.loginToolStripMenuItem.Text = " 登入(&L)";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // cancelLoginToolStripMenuItem
            // 
            this.cancelLoginToolStripMenuItem.Name = "cancelLoginToolStripMenuItem";
            this.cancelLoginToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.cancelLoginToolStripMenuItem.Text = "取消登入(&C)";
            this.cancelLoginToolStripMenuItem.Visible = false;
            this.cancelLoginToolStripMenuItem.Click += new System.EventHandler(this.cancelLoginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "登出(&L)";
            this.logoutToolStripMenuItem.Visible = false;
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // myCourseToolStripMenuItem
            // 
            this.myCourseToolStripMenuItem.Name = "myCourseToolStripMenuItem";
            this.myCourseToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.myCourseToolStripMenuItem.Text = "課程管理(&M)";
            this.myCourseToolStripMenuItem.Visible = false;
            this.myCourseToolStripMenuItem.Click += new System.EventHandler(this.myCourseToolStripMenuItem_Click);
            // 
            // btn_readySelCoursesList
            // 
            this.btn_readySelCoursesList.Location = new System.Drawing.Point(321, 28);
            this.btn_readySelCoursesList.Name = "btn_readySelCoursesList";
            this.btn_readySelCoursesList.Size = new System.Drawing.Size(136, 23);
            this.btn_readySelCoursesList.TabIndex = 9;
            this.btn_readySelCoursesList.Text = "待選列表";
            this.btn_readySelCoursesList.UseVisualStyleBackColor = true;
            this.btn_readySelCoursesList.Click += new System.EventHandler(this.btn_readySelCoursesList_Click);
            // 
            // checkBox_OnHook
            // 
            this.checkBox_OnHook.AutoSize = true;
            this.checkBox_OnHook.Enabled = false;
            this.checkBox_OnHook.Location = new System.Drawing.Point(107, 341);
            this.checkBox_OnHook.Name = "checkBox_OnHook";
            this.checkBox_OnHook.Size = new System.Drawing.Size(72, 16);
            this.checkBox_OnHook.TabIndex = 10;
            this.checkBox_OnHook.Text = "掛機模式";
            this.checkBox_OnHook.UseVisualStyleBackColor = true;
            this.checkBox_OnHook.CheckedChanged += new System.EventHandler(this.checkBox_OnHook_CheckedChanged);
            // 
            // checkBox_OnSchedule
            // 
            this.checkBox_OnSchedule.AutoSize = true;
            this.checkBox_OnSchedule.Enabled = false;
            this.checkBox_OnSchedule.Location = new System.Drawing.Point(330, 282);
            this.checkBox_OnSchedule.Name = "checkBox_OnSchedule";
            this.checkBox_OnSchedule.Size = new System.Drawing.Size(72, 16);
            this.checkBox_OnSchedule.TabIndex = 11;
            this.checkBox_OnSchedule.Text = "排程執行";
            this.checkBox_OnSchedule.UseVisualStyleBackColor = true;
            this.checkBox_OnSchedule.CheckedChanged += new System.EventHandler(this.checkBox_OnSchedule_CheckedChanged);
            // 
            // group_TimePicker
            // 
            this.group_TimePicker.Controls.Add(this.dateTimePicker_OnSchedule);
            this.group_TimePicker.Location = new System.Drawing.Point(321, 282);
            this.group_TimePicker.Name = "group_TimePicker";
            this.group_TimePicker.Size = new System.Drawing.Size(136, 53);
            this.group_TimePicker.TabIndex = 12;
            this.group_TimePicker.TabStop = false;
            // 
            // dateTimePicker_OnSchedule
            // 
            this.dateTimePicker_OnSchedule.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimePicker_OnSchedule.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_OnSchedule.Location = new System.Drawing.Point(7, 22);
            this.dateTimePicker_OnSchedule.MinDate = new System.DateTime(2017, 12, 30, 0, 0, 0, 0);
            this.dateTimePicker_OnSchedule.Name = "dateTimePicker_OnSchedule";
            this.dateTimePicker_OnSchedule.ShowUpDown = true;
            this.dateTimePicker_OnSchedule.Size = new System.Drawing.Size(121, 22);
            this.dateTimePicker_OnSchedule.TabIndex = 0;
            this.dateTimePicker_OnSchedule.Value = new System.DateTime(2018, 1, 7, 0, 0, 0, 0);
            // 
            // lb_currentTime
            // 
            this.lb_currentTime.AutoSize = true;
            this.lb_currentTime.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lb_currentTime.Location = new System.Drawing.Point(307, 388);
            this.lb_currentTime.Name = "lb_currentTime";
            this.lb_currentTime.Size = new System.Drawing.Size(150, 17);
            this.lb_currentTime.TabIndex = 13;
            this.lb_currentTime.Text = "0000/00/00 - 00:00:00";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.cancelLoginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.myCourseToolStripMenuItem,
            this.searchCourseToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(465, 24);
            this.menuStrip.TabIndex = 8;
            this.menuStrip.Text = "menuStrip1";
            // 
            // searchCourseToolStripMenuItem
            // 
            this.searchCourseToolStripMenuItem.Name = "searchCourseToolStripMenuItem";
            this.searchCourseToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.searchCourseToolStripMenuItem.Text = "修課學生查詢(&S)";
            this.searchCourseToolStripMenuItem.Visible = false;
            this.searchCourseToolStripMenuItem.Click += new System.EventHandler(this.searchCourseToolStripMenuItem_Click);
            // 
            // btn_StartReg
            // 
            this.btn_StartReg.Location = new System.Drawing.Point(321, 86);
            this.btn_StartReg.Name = "btn_StartReg";
            this.btn_StartReg.Size = new System.Drawing.Size(136, 23);
            this.btn_StartReg.TabIndex = 14;
            this.btn_StartReg.Text = "篩選登記";
            this.btn_StartReg.UseVisualStyleBackColor = true;
            this.btn_StartReg.Click += new System.EventHandler(this.btn_StartReg_Click);
            // 
            // btn_StartSel
            // 
            this.btn_StartSel.Location = new System.Drawing.Point(321, 86);
            this.btn_StartSel.Name = "btn_StartSel";
            this.btn_StartSel.Size = new System.Drawing.Size(136, 23);
            this.btn_StartSel.TabIndex = 15;
            this.btn_StartSel.Text = "輔助加選";
            this.btn_StartSel.UseVisualStyleBackColor = true;
            this.btn_StartSel.Click += new System.EventHandler(this.btn_StartSel_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(321, 86);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(136, 23);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // checkBox_DelCourseFirst
            // 
            this.checkBox_DelCourseFirst.AutoSize = true;
            this.checkBox_DelCourseFirst.Enabled = false;
            this.checkBox_DelCourseFirst.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_DelCourseFirst.ForeColor = System.Drawing.Color.Red;
            this.checkBox_DelCourseFirst.Location = new System.Drawing.Point(107, 363);
            this.checkBox_DelCourseFirst.Name = "checkBox_DelCourseFirst";
            this.checkBox_DelCourseFirst.Size = new System.Drawing.Size(84, 16);
            this.checkBox_DelCourseFirst.TabIndex = 17;
            this.checkBox_DelCourseFirst.Text = "先退選模式";
            this.checkBox_DelCourseFirst.UseVisualStyleBackColor = true;
            this.checkBox_DelCourseFirst.CheckedChanged += new System.EventHandler(this.checkBox_DelCourseFirst_CheckedChanged);
            // 
            // btn_readyDelCoursesList
            // 
            this.btn_readyDelCoursesList.Location = new System.Drawing.Point(321, 57);
            this.btn_readyDelCoursesList.Name = "btn_readyDelCoursesList";
            this.btn_readyDelCoursesList.Size = new System.Drawing.Size(136, 23);
            this.btn_readyDelCoursesList.TabIndex = 18;
            this.btn_readyDelCoursesList.Text = "待退列表";
            this.btn_readyDelCoursesList.UseVisualStyleBackColor = true;
            this.btn_readyDelCoursesList.Click += new System.EventHandler(this.btn_readyDelCoursesList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 407);
            this.Controls.Add(this.btn_readyDelCoursesList);
            this.Controls.Add(this.checkBox_OnSchedule);
            this.Controls.Add(this.checkBox_DelCourseFirst);
            this.Controls.Add(this.btn_StartReg);
            this.Controls.Add(this.btn_StartSel);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.lb_currentTime);
            this.Controls.Add(this.group_TimePicker);
            this.Controls.Add(this.checkBox_OnHook);
            this.Controls.Add(this.btn_readySelCoursesList);
            this.Controls.Add(this.radio_selection);
            this.Controls.Add(this.radio_register);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.txt_Log);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "CYCU CSYS Helper BY J4S0N.H";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cmenu_txtLog.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.group_TimePicker.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Log;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel slb_LoginAs;
        private System.Windows.Forms.RadioButton radio_register;
        private System.Windows.Forms.RadioButton radio_selection;
        private System.Windows.Forms.ContextMenuStrip cmenu_txtLog;
        private System.Windows.Forms.ToolStripMenuItem clearLog_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Button btn_readySelCoursesList;
        private System.Windows.Forms.CheckBox checkBox_OnHook;
        private System.Windows.Forms.ToolStripMenuItem myCourseToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_OnSchedule;
        private System.Windows.Forms.GroupBox group_TimePicker;
        private System.Windows.Forms.DateTimePicker dateTimePicker_OnSchedule;
        private System.Windows.Forms.Label lb_currentTime;
        private System.Windows.Forms.ToolStripMenuItem cancelLoginToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button btn_StartReg;
        private System.Windows.Forms.Button btn_StartSel;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox checkBox_DelCourseFirst;
        private System.Windows.Forms.Button btn_readyDelCoursesList;
        private System.Windows.Forms.ToolStripMenuItem searchCourseToolStripMenuItem;
    }
}

