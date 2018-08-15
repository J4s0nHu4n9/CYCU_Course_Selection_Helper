using System;
using System.Drawing;
using System.Windows.Forms;

namespace CYCU_Course_Selection_Helper
{
    public partial class CourseStudentListForm : Form
    {
        public string OpCode { set; get; }

        public int LastSearchIndex { set; get; }

        public CourseStudentListForm()
        {
            InitializeComponent();
        }

        private void CourseStudentListForm_Load(object sender, EventArgs e)
        {
            LastSearchIndex = -1;
            if (HttpCommunication.GetCourseStudents(OpCode, out dynamic datas, out string msg))
            {
                listView_Students.Items.Clear();
                if (datas != null)
                {
                    foreach (var data in datas)
                    {
                        listView_Students.Items.Add(new ListViewItem(new string[] { data.idcode }));
                    }
                }
            }
            statusLabel.Text = msg;
        }

        private void listView_Students_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                Close();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string id_Str = txt_StuID.Text;
            for (int i = 0; i < listView_Students.Items.Count; i++)
            {
                if (listView_Students.Items[i].SubItems[0].Text.Contains(id_Str))
                {
                    if (i <= LastSearchIndex) continue;
                    else LastSearchIndex = i;

                    listView_Students.SelectedIndices.Clear();
                    listView_Students.SelectedIndices.Add(i);
                    listView_Students.Items[i].EnsureVisible();

                    return;
                }

                //  Loop results
                if (LastSearchIndex != -1 && (i + 1) == listView_Students.Items.Count)
                {
                    LastSearchIndex = -1;
                    i = -1;
                }
            }
        }
    }
}
