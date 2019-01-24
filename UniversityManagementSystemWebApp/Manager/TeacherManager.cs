using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        // save teacher in database
        public string Save(Teacher teacher)
        {
            // check teacher email already exists or not
            if (teacherGateway.CheckEmailExists(teacher.Email))
            {
                return "Exists";
            }
            else
            {
                int rowsAffected = teacherGateway.Save(teacher);

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

        // get teacher by departmentId
        public List<Teacher> GetAllTeachersByDepartment(int departmentId)
        {
            return teacherGateway.GetAllTeachersByDepartment(departmentId);
        }

        // get teacher info by teacher id
        public Teacher GetTeacherByTeacherId(int teacherId)
        {
            return teacherGateway.GetTeacherByTeacherId(teacherId);
        }

        // get total credit taken by teacher
        public decimal GetTotalCourseCreditTakenByTeacher(int teacherId)
        {
            return teacherGateway.GetTotalCourseCreditTakenByTeacher(teacherId);
        }

        //assign course to teacher (Save in AssignCourseTable)
        public string CourseAssign(AssignCourseToTeacher assignCourse)
        {
            // check course already assigned or not
            if (teacherGateway.IsAssigned(assignCourse))
            {
                return "Exists";
            }
            else
            {
                int rowsAffected = teacherGateway.CourseAssign(assignCourse);

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
    }
}