using ABC_Ed_Services.DBServiceRef;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
   
    public partial class frmCourses : Form
    {
        private List<Course> courseList;
        public frmCourses()
        {
            InitializeComponent();
        }

        private void frmCourses_Load(object sender, EventArgs e)
        {
            Tafe_DataTier dt = new Tafe_DataTier();
            courseList = dt.viewCourses();


            foreach (Course c in courseList)
            {
                lbCourses.Items.Add(c.CourseID.ToString() + "-->" + c.CourseName.ToString()); ;

            }
        }

        private void lbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
    }
}