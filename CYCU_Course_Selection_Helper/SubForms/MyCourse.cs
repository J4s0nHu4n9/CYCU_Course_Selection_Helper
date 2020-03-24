using System;
using System.Windows.Forms;
using CYCU_Course_Selection_Helper.Models;

namespace CYCU_Course_Selection_Helper.SubForms
{
    public partial class MyCourse : Form
    {
        public MyCourse()
        {
            InitializeComponent();
        }

        private void MyCourse_Load(object sender, EventArgs e)
        {
            //  強制觸發 SelectedIndexChanged 事件
            tab_Courses_SelectedIndexChanged(null, null);
        }

        private void RefreshCourseList()
        {

            if (HttpCommunication.GetAllMyCourses(ProgramData.LoginId, out dynamic datas, out string msg))
            {
                listView_Courses.Items.Clear();
                if (datas != null)
                {
                    foreach (var data in datas)
                    {
                        listView_Courses.Items.Add(new ListViewItem(new string[] { data.op_type, data.op_code, data.cname, data.teacher }));
                    }
                }
            }

            statusLabel.Text = msg;
            btn_delSelection.Enabled = false;
        }

        private void RefreshAppendList()
        {

            if (HttpCommunication.GetAllMyCoursesAppend(ProgramData.LoginId, out dynamic datas, out string msg))
            {
                listView_Appends.Items.Clear();
                if (datas != null)
                {
                    foreach (var data in datas)
                    {
                        listView_Appends.Items.Add(new ListViewItem(new string[] { data.ord, data.op_type, data.op_code, data.cname, data.teacher }));
                    }
                }
            }

            statusLabel.Text = msg;
            btn_delAppend.Enabled = false;
        }

        private void btn_delSelection_Click(object sender, EventArgs e)
        {
            string seletedItemString = listView_Courses.SelectedItems[0].SubItems[2].Text + "(" + listView_Courses.SelectedItems[0].SubItems[1].Text + ")";
            string opcode = listView_Courses.SelectedItems[0].SubItems[1].Text;
            string msg = null;

            if (MessageBox.Show(
                "您確定要退選 [" + seletedItemString + "] 嗎", 
                "確認退選", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (HttpCommunication.DeleteSelection(opcode, out msg))
                {
                    MessageBox.Show(msg, "退選成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "退選失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            RefreshCourseList();
        }

        private void btn_delAppend_Click(object sender, EventArgs e)
        {
            string seletedItemString = listView_Appends.SelectedItems[0].SubItems[3].Text + "(" + listView_Appends.SelectedItems[0].SubItems[1].Text + ")";
            string opcode = listView_Appends.SelectedItems[0].SubItems[2].Text;
            string msg = null;

            if (MessageBox.Show(
                "您確定要取消遞補 [" + seletedItemString + "] 嗎",
                "確認取消遞補",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (HttpCommunication.DeleteAppend(opcode, out msg))
                {
                    MessageBox.Show(msg, "取消遞補成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(msg, "取消遞補失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            RefreshAppendList();
        }

        private void listView_Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Courses.SelectedItems.Count > 0)
            {
                string seletedItemString = "已選擇 " + listView_Courses.SelectedItems[0].SubItems[2].Text + "(" + listView_Courses.SelectedItems[0].SubItems[1].Text + ")";
                statusLabel.Text = seletedItemString;
                btn_delSelection.Enabled = true;
            }
            else
            {
                statusLabel.Text = "未選取任何項目";
                btn_delSelection.Enabled = false;
            }
        }

        private void listView_Appends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_Appends.SelectedItems.Count > 0)
            {
                string seletedItemString = "已選擇 " + listView_Appends.SelectedItems[0].SubItems[3].Text + "(" + listView_Appends.SelectedItems[0].SubItems[2].Text + ")";
                statusLabel.Text = seletedItemString;
                btn_delAppend.Enabled = true;
            }
            else
            {
                statusLabel.Text = "未選取任何項目";
                btn_delAppend.Enabled = false;
            }
        }

        private void tab_Courses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_Courses.SelectedTab == tabPage_Courses)
            {
                RefreshCourseList();
                btn_delSelection.Visible = true;
                btn_delAppend.Visible = false;
            }
            else if (tab_Courses.SelectedTab == tabPage_Appends)
            {
                RefreshAppendList();
                btn_delSelection.Visible = false;
                btn_delAppend.Visible = true;
            }
        }

        private void MyCourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }

        private void selectedCourseMenuItem_LookupStuList_Click(object sender, EventArgs e)
        {
            string opcode = listView_Courses.SelectedItems[0].SubItems[1].Text;

            CourseStudentListForm stuList = new CourseStudentListForm();
            stuList.OpCode = opcode;
            stuList.ShowDialog();
        }

        private void appendCourseMenuItem_LookupStuList_Click(object sender, EventArgs e)
        {
            string opcode = listView_Appends.SelectedItems[0].SubItems[2].Text;

            CourseStudentListForm stuList = new CourseStudentListForm();
            stuList.OpCode = opcode;
            stuList.ShowDialog();
        }

        private void listView_Courses_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Courses.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenu_SelectedCourse.Show(Cursor.Position);
                }
            }
        }

        private void listView_Appends_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView_Appends.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenu_AppendCourse.Show(Cursor.Position);
                }
            }
        }
    }
}
