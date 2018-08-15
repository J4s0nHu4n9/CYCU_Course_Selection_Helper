using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CYCU_Course_Selection_Helper
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {
            FileIO.LoadFileFromTxt("sel_courses.list", out ProgramData.ReadyToSelectCoursesList);

            foreach (var item in ProgramData.ReadyToSelectCoursesList)
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
            ProgramData.ReadyToSelectCoursesList.Clear();
            for (var i = 0; i < list_Course.Items.Count; i++)
                ProgramData.ReadyToSelectCoursesList.Add(list_Course.Items[i].Text);

            FileIO.SaveListToTxt("sel_courses.list", ProgramData.ReadyToSelectCoursesList);

            Close();
        }

        private void AddCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                btn_Submit.PerformClick();
        }
    }
}
