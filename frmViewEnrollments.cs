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
    public partial class frmViewEnrollments : Form
    {
        private List<Course> courseList;
        public frmViewEnrollments()
        {
            InitializeComponent();
        }

        private void frmViewEnrollments_Load(object sender, EventArgs e)
        {
            cbCourses.Text = "-Select Courset-";
            Tafe_DataTier dt = new Tafe_DataTier();
            courseList = dt.viewCourses();


            foreach (Course c in courseList)
            {
                cbCourses.Items.Add(c.CourseID.ToString()); ;

            }
        }

        private void cbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbStudents.Items.Clear();
            string id = cbCourses.SelectedItem.ToString();
            this.txtName.Text = (courseList.Where(c=>c.CourseID == id).FirstOrDefault()).CourseName;
            this.txtCost.Text = (courseList.Where(c => c.CourseID == id).FirstOrDefault()).Cost.ToString("C");

            Tafe_DataTier dt = new Tafe_DataTier();
            var studList = dt.getStudentsEnrolledInCourse(id);
            if (studList.Count() <=0)
            {
                lbStudents.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else
            {  
                foreach(var s in studList)
                {
                    this.lbStudents.Items.Add(s.StudentID + "-->" + s.StduentName);
                }
            }
        }
    }
}