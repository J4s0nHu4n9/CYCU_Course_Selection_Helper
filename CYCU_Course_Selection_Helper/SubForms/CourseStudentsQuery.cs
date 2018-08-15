using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CYCU_Course_Selection_Helper
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
