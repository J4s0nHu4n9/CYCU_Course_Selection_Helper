namespace CYCU_Course_Selection_Helper.SubForms
{
    partial class Login
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
            this.btn_Login = new System.Windows.Forms.Button();
            this.lb_stuID = new System.Windows.Forms.Label();
            this.lb_stuPW = new System.Windows.Forms.Label();
            this.txt_stuID = new System.Windows.Forms.TextBox();
            this.txt_stuPW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(212, 16);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(105, 50);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "確定";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // lb_stuID
            // 
            this.lb_stuID.AutoSize = true;
            this.lb_stuID.Location = new System.Drawing.Point(12, 21);
            this.lb_stuID.Name = "lb_stuID";
            this.lb_stuID.Size = new System.Drawing.Size(41, 12);
            this.lb_stuID.TabIndex = 1;
            this.lb_stuID.Text = "帳號：";
            // 
            // lb_stuPW
            // 
            this.lb_stuPW.AutoSize = true;
            this.lb_stuPW.Location = new System.Drawing.Point(12, 50);
            this.lb_stuPW.Name = "lb_stuPW";
            this.lb_stuPW.Size = new System.Drawing.Size(41, 12);
            this.lb_stuPW.TabIndex = 2;
            this.lb_stuPW.Text = "密碼：";
            // 
            // txt_stuID
            // 
            this.txt_stuID.Location = new System.Drawing.Point(60, 16);
            this.txt_stuID.Name = "txt_stuID";
            this.txt_stuID.Size = new System.Drawing.Size(147, 22);
            this.txt_stuID.TabIndex = 0;
            // 
            // txt_stuPW
            // 
            this.txt_stuPW.Location = new System.Drawing.Point(59, 44);
            this.txt_stuPW.Name = "txt_stuPW";
            this.txt_stuPW.Size = new System.Drawing.Size(147, 22);
            this.txt_stuPW.TabIndex = 1;
            this.txt_stuPW.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 80);
            this.Controls.Add(this.txt_stuPW);
            this.Controls.Add(this.txt_stuID);
            this.Controls.Add(this.lb_stuPW);
            this.Controls.Add(this.lb_stuID);
            this.Controls.Add(this.btn_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.KeyPreview = true;
            this.Name = "Login";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "登入";
            this.TopMost = true;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label lb_stuID;
        private System.Windows.Forms.Label lb_stuPW;
        private System.Windows.Forms.TextBox txt_stuID;
        private System.Windows.Forms.TextBox txt_stuPW;
    }
}