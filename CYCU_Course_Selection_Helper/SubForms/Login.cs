using System;
using System.Windows.Forms;
using CYCU_Course_Selection_Helper.Models;

namespace CYCU_Course_Selection_Helper.SubForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_stuID.Text.Trim().Length < 5 || txt_stuPW.Text.Length < 5)
            {
                MessageBox.Show("帳號及密碼長度必須不為空且長度大於 5 字元", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProgramData.LoginId = txt_stuID.Text;
            ProgramData.LoginPw = txt_stuPW.Text;
            ProgramData.AcceptToConnect = true;
            Close();
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }
    }
}
