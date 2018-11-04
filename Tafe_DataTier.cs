using System;
using System.Collections.Generic;
using ABC_Ed_Services.DBServiceRef;

namespace ABC_Ed_Services
{

    class Tafe_DataTier{
        private IDBService proxy;
        public Tafe_DataTier(){

            proxy = new DBServiceRef.DBServiceClient("MybasicHttpBinding");
        }


        public int insertStudent(string id, string name, DateTime dateEnrolled)
        {
            int rowsUpdated;
            try
            {
                rowsUpdated = proxy.InsertAStudent(new Student
                {
                    StudentID = id,
                    StduentName = name,
                    DateEnrolled = dateEnrolled
                });
            }
            catch (Exception)
            {
                rowsUpdated = -1;
            }

            return rowsUpdated;
        }



        public int insertCourse(string id, string name, Decimal cost)
        {
            int rowsUpdated;
            try
            {
                rowsUpdated = proxy.InsertACourse(new Course
                {
                    CourseID = id,
                    CourseName = name,
                    Cost = cost
                });
            }
            catch (Exception)
            {
                rowsUpdated = -1;
            }

            return rowsUpdated;
        }


        public List<Student> viewStudents()
        {
            List<Student> list = proxy.GetAllStudents();
            return list;
        }

        public List<Course> viewCourses()
        {
            List<Course> list = proxy.GetAllCourses();
            return list;
        }


        public int enroll(String courseID, String studentID){

            int rowsUpdated;
            try
            {
                rowsUpdated = proxy.InsertEnrolment(new Enrollment
                {
                    StudentID = studentID,
                    CourseID = courseID,
                    Grade = "NR"
                });
            }
            catch (Exception)
            {
                rowsUpdated = -1;
            }

            return rowsUpdated;
        }

        public List<Course> getEnrollmentsForStudent(string studentID)
        {
            var list = proxy.GetEnrollmentsForStudent(studentID);
            return list;
        }

        public List<Student> getStudentsEnrolledInCourse(string courseID)
        {
            var list = proxy.getStudentsEnrolledInCourse(courseID);
            return list;

        }
    }
}
