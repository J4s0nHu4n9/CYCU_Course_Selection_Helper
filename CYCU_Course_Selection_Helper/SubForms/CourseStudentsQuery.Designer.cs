namespace CYCU_Course_Selection_Helper
{
    partial class CourseStudentsQuery
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
            this.lb_QueryOpCode = new System.Windows.Forms.Label();
            this.txt_QueryOpCode = new System.Windows.Forms.TextBox();
            this.btn_Query = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_QueryOpCode
            // 
            this.lb_QueryOpCode.AutoSize = true;
            this.lb_QueryOpCode.Location = new System.Drawing.Point(12, 18);
            this.lb_QueryOpCode.Name = "lb_QueryOpCode";
            this.lb_QueryOpCode.Size = new System.Drawing.Size(65, 12);
            this.lb_QueryOpCode.TabIndex = 0;
            this.lb_QueryOpCode.Text = "課程代碼：";
            // 
            // txt_QueryOpCode
            // 
            this.txt_QueryOpCode.Location = new System.Drawing.Point(84, 13);
            this.txt_QueryOpCode.Name = "txt_QueryOpCode";
            this.txt_QueryOpCode.Size = new System.Drawing.Size(117, 22);
            this.txt_QueryOpCode.TabIndex = 1;
            // 
            // btn_Query
            // 
            this.btn_Query.Location = new System.Drawing.Point(14, 41);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(187, 23);
            this.btn_Query.TabIndex = 2;
            this.btn_Query.Text = "查詢";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // CourseStudentsQuery
            // 
            this.AcceptButton = this.btn_Query;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 76);
            this.Controls.Add(this.btn_Query);
            this.Controls.Add(this.txt_QueryOpCode);
            this.Controls.Add(this.lb_QueryOpCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CourseStudentsQuery";
            this.Text = "查詢修課同學";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_QueryOpCode;
        private System.Windows.Forms.TextBox txt_QueryOpCode;
        private System.Windows.Forms.Button btn_Query;
    }
}