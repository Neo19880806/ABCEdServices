using ABC_Ed_Services.DBServiceRef;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ABC_Ed_Services
{
    public partial class frmBilling : Form
    {
        private List<Student> studList;
        private Tafe_DataTier dt;

        public frmBilling()
        {
            dt = new Tafe_DataTier();
            InitializeComponent();
        }

        private void cbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbCourses.Items.Clear();
            string id = cbStudents.SelectedItem.ToString();
            this.txtName.Text = (studList.Where(s=>s.StudentID == id)).FirstOrDefault().StduentName;

            dt = new Tafe_DataTier();
            List<Course> courseList= dt.getEnrollmentsForStudent(id);

            Decimal total = 0.0M;
            if (courseList.Count() <=0)
            {
                lbCourses.Items.Add("--------- NO ENROLLMENTS ----------");
            }
            else
            {
                foreach (var c in courseList)
                {
                    lbCourses.Items.Add(c.CourseName);
                    total = total + c.Cost;
                }
            }
            txtCost.Text = total.ToString("C");
        }

        private void frmBilling_Load(object sender, EventArgs e)
        {
            cbStudents.Text = "-Select Student-";
            studList = dt.viewStudents();
            foreach (Student s in studList)
            {
                cbStudents.Items.Add(s.StudentID.ToString()); ;
            }
        }
    }
}