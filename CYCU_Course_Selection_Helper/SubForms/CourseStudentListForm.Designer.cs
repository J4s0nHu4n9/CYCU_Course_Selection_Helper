namespace CYCU_Course_Selection_Helper
{
    partial class CourseStudentListForm
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
            this.listView_Students = new System.Windows.Forms.ListView();
            this.columnStuID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_StuID = new System.Windows.Forms.Label();
            this.txt_StuID = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_Students
            // 
            this.listView_Students.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnStuID});
            this.listView_Students.FullRowSelect = true;
            this.listView_Students.HideSelection = false;
            this.listView_Students.Location = new System.Drawing.Point(12, 12);
            this.listView_Students.Name = "listView_Students";
            this.listView_Students.Size = new System.Drawing.Size(159, 398);
            this.listView_Students.TabIndex = 2;
            this.listView_Students.UseCompatibleStateImageBehavior = false;
            this.listView_Students.View = System.Windows.Forms.View.Details;
            this.listView_Students.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView_Students_KeyPress);
            // 
            // columnStuID
            // 
            this.columnStuID.Text = "學號";
            this.columnStuID.Width = 95;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(184, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(31, 17);
            this.statusLabel.Text = "        ";
            // 
            // lb_StuID
            // 
            this.lb_StuID.AutoSize = true;
            this.lb_StuID.Location = new System.Drawing.Point(12, 421);
            this.lb_StuID.Name = "lb_StuID";
            this.lb_StuID.Size = new System.Drawing.Size(41, 12);
            this.lb_StuID.TabIndex = 2;
            this.lb_StuID.Text = "學號：";
            // 
            // txt_StuID
            // 
            this.txt_StuID.Location = new System.Drawing.Point(52, 416);
            this.txt_StuID.Name = "txt_StuID";
            this.txt_StuID.Size = new System.Drawing.Size(119, 22);
            this.txt_StuID.TabIndex = 0;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(12, 444);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(159, 25);
            this.btn_Search.TabIndex = 1;
            this.btn_Search.Text = "搜尋";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // CourseStudentListForm
            // 
            this.AcceptButton = this.btn_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 499);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_StuID);
            this.Controls.Add(this.lb_StuID);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView_Students);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CourseStudentListForm";
            this.Text = "學生清單";
            this.Load += new System.EventHandler(this.CourseStudentListForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_Students;
        private System.Windows.Forms.ColumnHeader columnStuID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Label lb_StuID;
        private System.Windows.Forms.TextBox txt_StuID;
        private System.Windows.Forms.Button btn_Search;
    }
}