using ABC_Ed_Services.DBServiceRef;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
    public partial class frmEnroll : Form
    {
        private List<Student> studList;
        private List<Course> courseList;
        private Tafe_DataTier dt;

        public frmEnroll()
        {
            InitializeComponent();
            dt = new Tafe_DataTier();
        }

        private void frmEnroll_Load(object sender, EventArgs e)
        {
            cbStudents.Text = "-Select Student-";
            studList = dt.viewStudents();
            foreach (Student s in studList)
            {
                cbStudents.Items.Add(s.StudentID.ToString()); ;
            }

            cbCourses.Text = "-Select Course-";
            courseList = dt.viewCourses();
            foreach (Course c in courseList)
            {
                cbCourses.Items.Add(c.CourseID.ToString()); ;
            }

        }


        private void btnEnroll_Click(object sender, EventArgs e)
        {
            dt = new Tafe_DataTier();
            int rowsInserted = dt.enroll(cbCourses.SelectedItem.ToString(),cbStudents.SelectedItem.ToString());
            if (rowsInserted > 0)
            {
                MessageBox.Show("New Enrollment Information Saved", "Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("New Enrollment Information NOT Saved", "Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbStudents.SelectedItem.ToString();
            this.txtStudName.Text = (studList.Where(s=>s.StudentID == id)).FirstOrDefault().StduentName;
            txtDateEnrolled.Text = (studList.Where(c=>c.StudentID == id)).FirstOrDefault().DateEnrolled.ToString("d");
        }

        private void cbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = cbCourses.SelectedItem.ToString();
            txtCourseName.Text = (courseList.Where(c => c.CourseID == id).FirstOrDefault()).CourseName;
            this.txtCost.Text = (courseList.Where(c => c.CourseID == id).FirstOrDefault()).Cost.ToString("C");
        }
    }
}