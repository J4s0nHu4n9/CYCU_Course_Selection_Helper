namespace CYCU_Course_Selection_Helper.SubForms
{
    partial class MyCourse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_delSelection = new System.Windows.Forms.Button();
            this.listView_Courses = new System.Windows.Forms.ListView();
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnTeacher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tab_Courses = new System.Windows.Forms.TabControl();
            this.tabPage_Courses = new System.Windows.Forms.TabPage();
            this.tabPage_Appends = new System.Windows.Forms.TabPage();
            this.listView_Appends = new System.Windows.Forms.ListView();
            this.column_Order = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_Teacher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenu_AppendCourse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.appendCourseMenuItem_LookupStuList = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_delAppend = new System.Windows.Forms.Button();
            this.contextMenu_SelectedCourse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectedCourseMenuItem_LookupStuList = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.tab_Courses.SuspendLayout();
            this.tabPage_Courses.SuspendLayout();
            this.tabPage_Appends.SuspendLayout();
            this.contextMenu_AppendCourse.SuspendLayout();
            this.contextMenu_SelectedCourse.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_delSelection
            // 
            this.btn_delSelection.Location = new System.Drawing.Point(286, 294);
            this.btn_delSelection.Name = "btn_delSelection";
            this.btn_delSelection.Size = new System.Drawing.Size(128, 23);
            this.btn_delSelection.TabIndex = 0;
            this.btn_delSelection.Text = "退選";
            this.btn_delSelection.UseVisualStyleBackColor = true;
            this.btn_delSelection.Click += new System.EventHandler(this.btn_delSelection_Click);
            // 
            // listView_Courses
            // 
            this.listView_Courses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnType,
            this.columnCode,
            this.columnName,
            this.columnTeacher});
            this.listView_Courses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Courses.FullRowSelect = true;
            this.listView_Courses.Location = new System.Drawing.Point(3, 3);
            this.listView_Courses.Name = "listView_Courses";
            this.listView_Courses.Size = new System.Drawing.Size(388, 244);
            this.listView_Courses.TabIndex = 4;
            this.listView_Courses.UseCompatibleStateImageBehavior = false;
            this.listView_Courses.View = System.Windows.Forms.View.Details;
            this.listView_Courses.SelectedIndexChanged += new System.EventHandler(this.listView_Courses_SelectedIndexChanged);
            this.listView_Courses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Courses_MouseClick);
            // 
            // columnType
            // 
            this.columnType.Text = "種類";
            this.columnType.Width = 75;
            // 
            // columnCode
            // 
            this.columnCode.Text = "課程代碼";
            this.columnCode.Width = 87;
            // 
            // columnName
            // 
            this.columnName.Text = "課程名稱";
            this.columnName.Width = 141;
            // 
            // columnTeacher
            // 
            this.columnTeacher.Text = "授課教師";
            this.columnTeacher.Width = 78;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(426, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(34, 17);
            this.statusLabel.Text = "         ";
            // 
            // tab_Courses
            // 
            this.tab_Courses.Controls.Add(this.tabPage_Courses);
            this.tab_Courses.Controls.Add(this.tabPage_Appends);
            this.tab_Courses.Location = new System.Drawing.Point(12, 12);
            this.tab_Courses.Name = "tab_Courses";
            this.tab_Courses.SelectedIndex = 0;
            this.tab_Courses.Size = new System.Drawing.Size(402, 276);
            this.tab_Courses.TabIndex = 3;
            this.tab_Courses.SelectedIndexChanged += new System.EventHandler(this.tab_Courses_SelectedIndexChanged);
            // 
            // tabPage_Courses
            // 
            this.tabPage_Courses.Controls.Add(this.listView_Courses);
            this.tabPage_Courses.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Courses.Name = "tabPage_Courses";
            this.tabPage_Courses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Courses.Size = new System.Drawing.Size(394, 250);
            this.tabPage_Courses.TabIndex = 0;
            this.tabPage_Courses.Text = "已選課程";
            this.tabPage_Courses.UseVisualStyleBackColor = true;
            // 
            // tabPage_Appends
            // 
            this.tabPage_Appends.Controls.Add(this.listView_Appends);
            this.tabPage_Appends.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Appends.Name = "tabPage_Appends";
            this.tabPage_Appends.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Appends.Size = new System.Drawing.Size(394, 250);
            this.tabPage_Appends.TabIndex = 1;
            this.tabPage_Appends.Text = "遞補清單";
            this.tabPage_Appends.UseVisualStyleBackColor = true;
            // 
            // listView_Appends
            // 
            this.listView_Appends.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_Order,
            this.column_Type,
            this.column_Code,
            this.column_Name,
            this.column_Teacher});
            this.listView_Appends.ContextMenuStrip = this.contextMenu_AppendCourse;
            this.listView_Appends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Appends.FullRowSelect = true;
            this.listView_Appends.Location = new System.Drawing.Point(3, 3);
            this.listView_Appends.Name = "listView_Appends";
            this.listView_Appends.Size = new System.Drawing.Size(388, 244);
            this.listView_Appends.TabIndex = 5;
            this.listView_Appends.UseCompatibleStateImageBehavior = false;
            this.listView_Appends.View = System.Windows.Forms.View.Details;
            this.listView_Appends.SelectedIndexChanged += new System.EventHandler(this.listView_Appends_SelectedIndexChanged);
            this.listView_Appends.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Appends_MouseClick);
            // 
            // column_Order
            // 
            this.column_Order.Text = "遞補排名";
            // 
            // column_Type
            // 
            this.column_Type.Text = "種類";
            this.column_Type.Width = 61;
            // 
            // column_Code
            // 
            this.column_Code.Text = "課程代碼";
            this.column_Code.Width = 66;
            // 
            // column_Name
            // 
            this.column_Name.Text = "課程名稱";
            this.column_Name.Width = 116;
            // 
            // column_Teacher
            // 
            this.column_Teacher.Text = "授課教師";
            this.column_Teacher.Width = 78;
            // 
            // contextMenu_AppendCourse
            // 
            this.contextMenu_AppendCourse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appendCourseMenuItem_LookupStuList});
            this.contextMenu_AppendCourse.Name = "contextMenu_AppendCourse";
            this.contextMenu_AppendCourse.Size = new System.Drawing.Size(123, 26);
            // 
            // appendCourseMenuItem_LookupStuList
            // 
            this.appendCourseMenuItem_LookupStuList.Name = "appendCourseMenuItem_LookupStuList";
            this.appendCourseMenuItem_LookupStuList.Size = new System.Drawing.Size(122, 22);
            this.appendCourseMenuItem_LookupStuList.Text = "查看同學";
            this.appendCourseMenuItem_LookupStuList.Click += new System.EventHandler(this.appendCourseMenuItem_LookupStuList_Click);
            // 
            // btn_delAppend
            // 
            this.btn_delAppend.Location = new System.Drawing.Point(286, 294);
            this.btn_delAppend.Name = "btn_delAppend";
            this.btn_delAppend.Size = new System.Drawing.Size(128, 23);
            this.btn_delAppend.TabIndex = 1;
            this.btn_delAppend.Text = "取消遞補";
            this.btn_delAppend.UseVisualStyleBackColor = true;
            this.btn_delAppend.Click += new System.EventHandler(this.btn_delAppend_Click);
            // 
            // contextMenu_SelectedCourse
            // 
            this.contextMenu_SelectedCourse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedCourseMenuItem_LookupStuList});
            this.contextMenu_SelectedCourse.Name = "contextMenu_SelectedCourse";
            this.contextMenu_SelectedCourse.Size = new System.Drawing.Size(123, 26);
            // 
            // selectedCourseMenuItem_LookupStuList
            // 
            this.selectedCourseMenuItem_LookupStuList.Name = "selectedCourseMenuItem_LookupStuList";
            this.selectedCourseMenuItem_LookupStuList.Size = new System.Drawing.Size(122, 22);
            this.selectedCourseMenuItem_LookupStuList.Text = "查看同學";
            this.selectedCourseMenuItem_LookupStuList.Click += new System.EventHandler(this.selectedCourseMenuItem_LookupStuList_Click);
            // 
            // MyCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 347);
            this.Controls.Add(this.tab_Courses);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_delSelection);
            this.Controls.Add(this.btn_delAppend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "MyCourse";
            this.Text = "課程管理";
            this.Load += new System.EventHandler(this.MyCourse_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyCourse_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tab_Courses.ResumeLayout(false);
            this.tabPage_Courses.ResumeLayout(false);
            this.tabPage_Appends.ResumeLayout(false);
            this.contextMenu_AppendCourse.ResumeLayout(false);
            this.contextMenu_SelectedCourse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_delSelection;
        private System.Windows.Forms.ListView listView_Courses;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnCode;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnTeacher;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TabControl tab_Courses;
        private System.Windows.Forms.TabPage tabPage_Courses;
        private System.Windows.Forms.TabPage tabPage_Appends;
        private System.Windows.Forms.ListView listView_Appends;
        private System.Windows.Forms.ColumnHeader column_Type;
        private System.Windows.Forms.ColumnHeader column_Code;
        private System.Windows.Forms.ColumnHeader column_Name;
        private System.Windows.Forms.ColumnHeader column_Teacher;
        private System.Windows.Forms.Button btn_delAppend;
        private System.Windows.Forms.ColumnHeader column_Order;
        private System.Windows.Forms.ContextMenuStrip contextMenu_SelectedCourse;
        private System.Windows.Forms.ToolStripMenuItem selectedCourseMenuItem_LookupStuList;
        private System.Windows.Forms.ContextMenuStrip contextMenu_AppendCourse;
        private System.Windows.Forms.ToolStripMenuItem appendCourseMenuItem_LookupStuList;
    }
}