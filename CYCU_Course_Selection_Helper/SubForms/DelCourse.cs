using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CYCU_Course_Selection_Helper.Models;

namespace CYCU_Course_Selection_Helper.SubForms
{
    public partial class DelCourse : Form
    {
        public DelCourse()
        {
            InitializeComponent();
        }

        private void DelCourse_Load(object sender, EventArgs e)
        {
            FileIo.LoadFileFromTxt("del_courses.list", out ProgramData.ReadyToDeleteCoursesList);

            foreach (var item in ProgramData.ReadyToDeleteCoursesList)
            {
                list_Course.Items.Add(item.ToString());
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"^[A-Z]{2}[0-9]{3}[A-Za-z]{1}$");
            string op_code_str = txt_Opcode.Text.Trim();
            if (!reg.IsMatch(op_code_str))
            {
                toolStripStatus_lb.Text = "課程代碼格式錯誤";
                toolStripStatus_lb.Visible = true;
            }
            else
            {
                for (var i = 0; i < list_Course.Items.Count; i++)
                {
                    if (op_code_str.Equals(list_Course.Items[i].Text))
                    {
                        toolStripStatus_lb.Text = "重複的課程代碼";
                        toolStripStatus_lb.Visible = true;
                        return;
                    }
                }

                list_Course.Items.Add(op_code_str);
                txt_Opcode.Text = "";
                toolStripStatus_lb.Visible = false;
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            list_Course.Items.Remove(list_Course.FocusedItem);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            ProgramData.ReadyToDeleteCoursesList.Clear();
            for (var i = 0; i < list_Course.Items.Count; i++)
                ProgramData.ReadyToDeleteCoursesList.Add(list_Course.Items[i].Text);

            FileIo.SaveListToTxt("del_courses.list", ProgramData.ReadyToDeleteCoursesList);

            Close();
        }

        private void DelCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                btn_Submit.PerformClick();
        }
    }
}
