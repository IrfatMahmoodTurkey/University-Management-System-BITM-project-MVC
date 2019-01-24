using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Manager
{
    public class CourseManager
    {
        private CourseGateway courseGateway;

        public CourseManager()
        {
            courseGateway = new CourseGateway();
        }

        // SAVE COURSE
        // save course in database
        public string Save(Course course)
        {
            // first check course code or name already exists or not in database
            if (courseGateway.CheckCodeNameIsExists(course))
            {
                return "Exists";
            }
            else
            {
                int rowsAffected = courseGateway.Save(course);

                if (rowsAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
        }

        // get all course by department id
        public List<Course> GetAllCoursesByDepartmentId(int departmentId)
        {
            return courseGateway.GetAllCoursesByDepartmentId(departmentId);
        }

        //get course by course id
        public Course GetCourseByCourseId(int courseId)
        {
            return courseGateway.GetCourseByCourseId(courseId);
        }

        // FOR VIEW COUSE STATICS

        // retrive course with teacher assigned by department
        public List<ViewCourseStaticsViewModel> GetAllCourseWithTeacherAssigned(int departmentId)
        {
            return courseGateway.GetAllCourseWithTeacherAssigned(departmentId);
        }
    }
}