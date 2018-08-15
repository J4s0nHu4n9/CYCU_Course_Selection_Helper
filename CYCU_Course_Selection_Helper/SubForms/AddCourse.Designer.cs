namespace CYCU_Course_Selection_Helper
{
    partial class AddCourse
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
            this.list_Course = new System.Windows.Forms.ListView();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.txt_Opcode = new System.Windows.Forms.TextBox();
            this.lb_Opcode = new System.Windows.Forms.Label();
            this.btn_Submit = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_lb = new System.Windows.Forms.ToolStripStatusLabel();
            this.column_CourseCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list_Course
            // 
            this.list_Course.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_CourseCode});
            this.list_Course.FullRowSelect = true;
            this.list_Course.Location = new System.Drawing.Point(12, 12);
            this.list_Course.MultiSelect = false;
            this.list_Course.Name = "list_Course";
            this.list_Course.Size = new System.Drawing.Size(163, 289);
            this.list_Course.TabIndex = 0;
            this.list_Course.UseCompatibleStateImageBehavior = false;
            this.list_Course.View = System.Windows.Forms.View.Details;
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(13, 364);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(163, 23);
            this.btn_Add.TabIndex = 3;
            this.btn_Add.Text = "加入";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(12, 307);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(163, 23);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "刪除選擇項目";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // txt_Opcode
            // 
            this.txt_Opcode.Location = new System.Drawing.Point(77, 336);
            this.txt_Opcode.Name = "txt_Opcode";
            this.txt_Opcode.Size = new System.Drawing.Size(98, 22);
            this.txt_Opcode.TabIndex = 2;
            // 
            // lb_Opcode
            // 
            this.lb_Opcode.AutoSize = true;
            this.lb_Opcode.Location = new System.Drawing.Point(12, 342);
            this.lb_Opcode.Name = "lb_Opcode";
            this.lb_Opcode.Size = new System.Drawing.Size(65, 12);
            this.lb_Opcode.TabIndex = 4;
            this.lb_Opcode.Text = "課程代碼：";
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(12, 393);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(163, 23);
            this.btn_Submit.TabIndex = 4;
            this.btn_Submit.Text = "確定";
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_lb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 424);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(188, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_lb
            // 
            this.toolStripStatus_lb.Name = "toolStripStatus_lb";
            this.toolStripStatus_lb.Size = new System.Drawing.Size(128, 17);
            this.toolStripStatus_lb.Text = "toolStripStatusLabel1";
            this.toolStripStatus_lb.Visible = false;
            // 
            // column_CourseCode
            // 
            this.column_CourseCode.Text = "課程代碼";
            this.column_CourseCode.Width = 150;
            // 
            // AddCourse
            // 
            this.AcceptButton = this.btn_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 446);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_Submit);
            this.Controls.Add(this.lb_Opcode);
            this.Controls.Add(this.txt_Opcode);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.list_Course);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "AddCourse";
            this.ShowInTaskbar = false;
            this.Text = "待選清單管理";
            this.Load += new System.EventHandler(this.AddCourse_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddCourse_KeyPress);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView list_Course;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.TextBox txt_Opcode;
        private System.Windows.Forms.Label lb_Opcode;
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_lb;
        private System.Windows.Forms.ColumnHeader column_CourseCode;
    }
}