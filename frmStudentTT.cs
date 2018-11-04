using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ABC_Ed_Services.DBServiceRef;
using System.Linq;

namespace ABC_Ed_Services
{
    public partial class frmStudentTT : Form
    {
        private List<Student> studList;

        public frmStudentTT()
        {
            InitializeComponent();
        }

        private void frmStudentTT_Load(object sender, EventArgs e)
        {
            
            cbStudents.Text = "-Select Student-";
            Tafe_DataTier dt = new Tafe_DataTier();
            studList = dt.viewStudents();
        
            
            foreach (Student s in studList)
            {
                cbStudents.Items.Add(s.StudentID.ToString()); ;
            }
           
        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
                lbCourses.Items.Clear();
                string id = cbStudents.SelectedItem.ToString();
                txtName.Text = (studList.Where(s=>s.StudentID == id).FirstOrDefault()).StduentName;
                txtDateEnrolled.Text = (studList.Where(s => s.StudentID == id).FirstOrDefault()).DateEnrolled.ToString("d");

                Tafe_DataTier dt = new Tafe_DataTier();
                var enrollmentList= dt.getEnrollmentsForStudent(id);

                if (enrollmentList.Count() <=0)
                {
                    lbCourses.Items.Add("--------- NO ENROLLMENTS ----------");
                }
                else
                {
                    foreach(var enroll in enrollmentList)
                    {
                        lbCourses.Items.Add(enroll.CourseID);
                    }
                }
        }

        private void lbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}