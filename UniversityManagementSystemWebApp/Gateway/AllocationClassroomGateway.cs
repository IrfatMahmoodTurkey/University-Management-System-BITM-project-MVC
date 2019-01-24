using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class AllocationClassroomGateway:CommonGateway
    {
        // ALLOCATE CLASSROOMS
        // allocate classrooms
        public int AllocateClassrooms(AllocateClassRoom allocateClassRoom)
        {
            Connection.Open();

            string query =
                "INSERT INTO AllocateClassRoom VALUES (@departmentId, @courseId, @roomId, @dayId, @startTime, @endTime, @type)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", allocateClassRoom.DepartmentId);
            Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);
            Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
            Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
            Command.Parameters.AddWithValue("@startTime", allocateClassRoom.StartTime);
            Command.Parameters.AddWithValue("@endTime", allocateClassRoom.EndTime);
            Command.Parameters.AddWithValue("@type", "ALLOCATED");

            int rowsAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowsAffected;
        }

        // get all from and to time by room no and day from allocate classrooms table
        public List<AllocateClassRoom> GetAllTimeForSameRoomAndDay(AllocateClassRoom allocateClassRoom)
        {
            Connection.Open();

            string query = "SELECT * FROM AllocateClassRoom WHERE RoomId = @roomId AND DayId = @dayId AND TYPE = 'ALLOCATED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
            Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);

            Reader = Command.ExecuteReader();
            List<AllocateClassRoom> allocateClassRooms = new List<AllocateClassRoom>();

            while (Reader.Read())
            {
                AllocateClassRoom allocateClass = new AllocateClassRoom();

                allocateClass.StartTime = Reader["StartTime"].ToString();
                allocateClass.EndTime = Reader["EndTime"].ToString();

                allocateClassRooms.Add(allocateClass);
            }

            Reader.Close();
            Connection.Close();

            return allocateClassRooms;
        } 

        //// get from time min by to hour
        //public int GetFromTimeMinByToHour(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE RoomId = @roomId AND DayId = @dayId AND FromHour = @toHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@toHour", allocateClassRoom.ToHour);

        //    Reader = Command.ExecuteReader();
        //    int fromMin = 0;

        //    while (Reader.Read())
        //    {
        //        fromMin = Convert.ToInt32(Reader["FromMin"]);
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    return fromMin;
        //}

        //// check time exists
        //public bool FromTimeIsExists(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE RoomId = @roomId AND DayId = @dayId AND FromHour = @toHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@toHour", allocateClassRoom.ToHour);

        //    Reader = Command.ExecuteReader();
        //    bool isExists = Reader.HasRows;

        //    Reader.Close();
        //    Connection.Close();

        //    return isExists;
        //}

        //// get to time min by from hour
        //public int GetToTimeMinByFromHour(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE RoomId = @roomId AND DayId = @dayId AND ToHour = @fromHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@FromHour", allocateClassRoom.FromHour);

        //    Reader = Command.ExecuteReader();
        //    int toMin = 0;

        //    while (Reader.Read())
        //    {
        //        toMin = Convert.ToInt32(Reader["ToMin"]);
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    return toMin;
        //}

        //// check time exists
        //public bool ToTimeIsExists(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE RoomId = @roomId AND DayId = @dayId AND ToHour = @fromHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@roomId", allocateClassRoom.RoomId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@FromHour", allocateClassRoom.FromHour);

        //    Reader = Command.ExecuteReader();
        //    bool isExists = Reader.HasRows;

        //    Reader.Close();
        //    Connection.Close();

        //    return isExists;
        //}

        //// -------------------------------------------------------------
        //// get time for same course, same day but different room
        


        // get all from and to time by day and course from allocate classrooms table
        public List<AllocateClassRoom> GetAllTimeByDiffRoomAndSameDay(AllocateClassRoom allocateClassRoom)
        {
            Connection.Open();

            string query = "SELECT * FROM AllocateClassRoom WHERE DayId = @dayId AND CourseId = @courseId AND TYPE = 'ALLOCATED'";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
            Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);

            Reader = Command.ExecuteReader();
            List<AllocateClassRoom> allocateClassRooms = new List<AllocateClassRoom>();

            while (Reader.Read())
            {
                AllocateClassRoom allocateClass = new AllocateClassRoom();

                allocateClass.StartTime = Reader["StartTime"].ToString();
                allocateClass.EndTime = Reader["EndTime"].ToString();

                allocateClassRooms.Add(allocateClass);
            }

            Reader.Close();
            Connection.Close();

            return allocateClassRooms;
        }


        //// check time exists
        //public bool ToTimeIsExistsSameDayAndCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE CourseId = @courseId AND DayId = @dayId AND ToHour = @fromHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@FromHour", allocateClassRoom.FromHour);

        //    Reader = Command.ExecuteReader();
        //    bool isExists = Reader.HasRows;

        //    Reader.Close();
        //    Connection.Close();

        //    return isExists;
        //}

        //// check time exists
        //public bool FromTimeIsExistsForSameDayAndCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE CourseId = @courseId AND DayId = @dayId AND FromHour = @toHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@toHour", allocateClassRoom.ToHour);

        //    Reader = Command.ExecuteReader();
        //    bool isExists = Reader.HasRows;

        //    Reader.Close();
        //    Connection.Close();

        //    return isExists;
        //}

        //// get to time min by from hour
        //public int GetToTimeMinByFromHourSameDaySameCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE CourseId = @courseId AND DayId = @dayId AND ToHour = @fromHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@CourseId", allocateClassRoom.CourseId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@FromHour", allocateClassRoom.FromHour);

        //    Reader = Command.ExecuteReader();
        //    int toMin = 0;

        //    while (Reader.Read())
        //    {
        //        toMin = Convert.ToInt32(Reader["ToMin"]);
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    return toMin;
        //}

        //// check time exists
        //public bool FromTimeIsExistsSameDayAndCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE CourseId = @courseId AND DayId = @dayId AND FromHour = @toHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@toHour", allocateClassRoom.ToHour);

        //    Reader = Command.ExecuteReader();
        //    bool isExists = Reader.HasRows;

        //    Reader.Close();
        //    Connection.Close();

        //    return isExists;
        //}

        //public int GetFromTimeMinByToHourSameDayAndCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    Connection.Open();

        //    string query = "SELECT * FROM AllocateClassRoom WHERE CourseId = @courseId AND DayId = @dayId AND FromHour = @toHour AND TYPE = 'ALLOCATED'";
        //    Command = new SqlCommand(query, Connection);

        //    Command.Parameters.AddWithValue("@courseId", allocateClassRoom.CourseId);
        //    Command.Parameters.AddWithValue("@dayId", allocateClassRoom.DayId);
        //    Command.Parameters.AddWithValue("@toHour", allocateClassRoom.ToHour);

        //    Reader = Command.ExecuteReader();
        //    int fromMin = 0;

        //    while (Reader.Read())
        //    {
        //        fromMin = Convert.ToInt32(Reader["FromMin"]);
        //    }

        //    Reader.Close();
        //    Connection.Close();

        //    return fromMin;
        //}






        //--------------------------------------------------------------

        //// VIEW CLASS SCHEDULE
        //// get class schedule by department id
        public List<ViewClassScheduleViewModel> GetAllocateClassRoomsByDepartmentId(int departmentId)
        {
            Connection.Open();

            string query = "  SELECT Course.Code AS Code, Course.Name AS Name, Room.RoomNo AS Room, Day.DayName AS DayName, AllocateClassRoom.StartTime AS StartTime, AllocateClassRoom.EndTime AS EndTime FROM Course LEFT JOIN AllocateClassRoom ON Course.Id = AllocateClassRoom.CourseId AND Type = 'ALLOCATED' LEFT JOIN Day ON Day.Id = AllocateClassRoom.DayId LEFT JOIN Room ON Room.Id = AllocateClassRoom.RoomId WHERE Course.DepartmentId = @departmentId";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@departmentId", departmentId);
            Reader = Command.ExecuteReader();
            List<ViewClassScheduleViewModel> allocateClassRooms = new List<ViewClassScheduleViewModel>();

            while (Reader.Read())
            {
                ViewClassScheduleViewModel allocateClassRoom = new ViewClassScheduleViewModel();

                allocateClassRoom.CourseCode = Reader["Code"].ToString();
                allocateClassRoom.CourseName = Reader["Name"].ToString();
                allocateClassRoom.RoomNo = Reader["Room"].ToString();
                allocateClassRoom.DayName = Reader["DayName"].ToString();
                allocateClassRoom.StartTime = Reader["StartTime"].ToString();
                allocateClassRoom.EndTime = Reader["EndTime"].ToString();

                allocateClassRooms.Add(allocateClassRoom);
            }

            Reader.Close();
            Connection.Close();

            return allocateClassRooms;
        } 
    }
}