using System;
using System.Windows.Forms;

namespace CYCU_Course_Selection_Helper.SubForms
{
    public partial class CourseStudentsQuery : Form
    {
        public CourseStudentsQuery()
        {
            InitializeComponent();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            CourseStudentListForm stuList = new CourseStudentListForm();
            stuList.OpCode = txt_QueryOpCode.Text.Trim();
            stuList.ShowDialog();
        }
    }
}
