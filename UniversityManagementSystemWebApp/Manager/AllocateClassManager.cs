using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Gateway;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.ViewModel;

namespace UniversityManagementSystemWebApp.Manager
{
    public class AllocateClassManager
    {
        private AllocationClassroomGateway allocationClassroomGateway;

        public AllocateClassManager()
        {
            allocationClassroomGateway = new AllocationClassroomGateway();
        }


        // Allocate class by timespan class (SIMPLE)
        public string AllocateClassrooms(AllocateClassRoom allocateClassRoom)
        {
            // this method returns 1 if no overlap found
            if (CheckClassOverLapped(allocateClassRoom) == 1)
            {
                int rowsAffected = allocationClassroomGateway.AllocateClassrooms(allocateClassRoom);

                if (rowsAffected > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Failed";
                }
            }
            else
            {
                return "Overlapped";
            }
        }

        // check class overlapped or not for same and different classroom
        public int CheckClassOverLapped(AllocateClassRoom allocateClassRoom)
        {
            List<AllocateClassRoom> sameRoomAndDays =
                allocationClassroomGateway.GetAllTimeForSameRoomAndDay(allocateClassRoom);

            TimeSpan startTimeUI = DateTime.Parse(allocateClassRoom.StartTime).TimeOfDay;
            TimeSpan endTimeUI = DateTime.Parse(allocateClassRoom.EndTime).TimeOfDay;
            int checkValue = 0;
            int returnValue = 0;

            foreach (AllocateClassRoom items in sameRoomAndDays)
            {
                TimeSpan startTimeFromDatabase = DateTime.Parse(items.StartTime).TimeOfDay;
                TimeSpan endTimeFromDatabase = DateTime.Parse(items.EndTime).TimeOfDay;

                if (startTimeUI <= startTimeFromDatabase && endTimeUI >= endTimeFromDatabase)
                {
                    checkValue++;
                }
                else if (startTimeUI >= startTimeFromDatabase && startTimeUI < endTimeFromDatabase)
                {
                    checkValue++;
                }
                else if (endTimeUI > startTimeFromDatabase && endTimeUI <= endTimeFromDatabase)
                {
                    checkValue++;
                }
            }

            if (checkValue <= 0)
            {
                List<AllocateClassRoom> diffRoomSameDay =
                    allocationClassroomGateway.GetAllTimeByDiffRoomAndSameDay(allocateClassRoom);
                int count = 0;

                foreach (AllocateClassRoom items in diffRoomSameDay)
                {
                    TimeSpan startTimeFromDatabase = DateTime.Parse(items.StartTime).TimeOfDay;
                    TimeSpan endTimeFromDatabase = DateTime.Parse(items.EndTime).TimeOfDay;

                    if (startTimeUI <= startTimeFromDatabase && endTimeUI >= endTimeFromDatabase)
                    {
                        count++;
                    }
                    else if (startTimeUI >= startTimeFromDatabase && startTimeUI < endTimeFromDatabase)
                    {
                        count++;
                    }
                    else if (endTimeUI > startTimeFromDatabase && endTimeUI <= endTimeFromDatabase)
                    {
                        count++;
                    }
                }

                if (count <= 0)
                {
                    returnValue = 1;
                }
                else
                {
                    returnValue = 0;
                }

                count = 0;
            }
            else
            {
                returnValue = 0;
            }

            checkValue = 0;

            return returnValue;
        }


        // COMPLEX CODES
        //public string AllocateClassRooms(AllocateClassroomViewModel allocateClassroomViewModel)
        //{
        //    // convert view model to main model
        //    AllocateClassRoom allocateClassRoom = ConvertMainModel(allocateClassroomViewModel);
        //    string returnString = null;

        //    //check time difference is one hour or valid
        //    if (allocateClassRoom.ToHour - allocateClassRoom.FromHour <= 0)
        //    {
        //        return "Invalid";
        //    }
        //    else
        //    {
        //        // check time overlap
        //        List<int> times = MakeListToCheckTimeOverlap(allocateClassRoom);

        //        if (times.Count <= 0)
        //        {
        //            // allocate class
        //            // here write the code
        //            List<int> timesOfSameDay = MakeListOfTimeForSameDayAndSameCourse(allocateClassRoom);

        //            if (timesOfSameDay.Count <= 0)
        //            {
        //                int rowsAffected = allocationClassroomGateway.AllocateClassrooms(allocateClassRoom);

        //                if (rowsAffected > 0)
        //                {
        //                    returnString = "Success";
        //                }
        //                else
        //                {
        //                    returnString = "Failed";
        //                }
        //            }
        //            else
        //            {
        //                if (CheckClassOverlapOnAnotherRoomSameDay(allocateClassRoom, timesOfSameDay))
        //                {
        //                    // overlapped
        //                    returnString = "Overlapped";
        //                }
        //                else
        //                {
        //                    if (!CheckOverlapByMinFromTimeSameDayAndSameCourse(allocateClassRoom) &&
        //                        !CheckOverlapByMinToTimeSameDayAndSameCourse(allocateClassRoom))
        //                    {
        //                        int rowsAffected = allocationClassroomGateway.AllocateClassrooms(allocateClassRoom);

        //                        if (rowsAffected > 0)
        //                        {
        //                            returnString = "Success";
        //                        }
        //                        else
        //                        {
        //                            returnString = "Failed";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        returnString = "Overlapped";
        //                    }
        //                } 
        //            }
        //        }
        //        else
        //        {
        //            if (CheckClassOverlapped(allocateClassRoom, times))
        //            {
        //                // overlapped
        //                returnString = "Overlapped";
        //            }
        //            else
        //            {
        //                if (!CheckOverlapByMinFromTime(allocateClassRoom) && !CheckOverlapByMinToTime(allocateClassRoom))
        //                {
        //                    // allocate class
        //                    // here have to write the cod
        //                    List<int> timesOfSameDay = MakeListOfTimeForSameDayAndSameCourse(allocateClassRoom);

        //                    if (timesOfSameDay.Count <= 0)
        //                    {
        //                        int rowsAffected = allocationClassroomGateway.AllocateClassrooms(allocateClassRoom);

        //                        if (rowsAffected > 0)
        //                        {
        //                            returnString = "Success";
        //                        }
        //                        else
        //                        {
        //                            returnString = "Failed";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (CheckClassOverlapOnAnotherRoomSameDay(allocateClassRoom, timesOfSameDay))
        //                        {
        //                            // overlapped
        //                            returnString = "Overlapped";
        //                        }
        //                        else
        //                        {
        //                            if (!CheckOverlapByMinFromTimeSameDayAndSameCourse(allocateClassRoom) &&
        //                                !CheckOverlapByMinToTimeSameDayAndSameCourse(allocateClassRoom))
        //                            {
        //                                int rowsAffected = allocationClassroomGateway.AllocateClassrooms(allocateClassRoom);

        //                                if (rowsAffected > 0)
        //                                {
        //                                    returnString = "Success";
        //                                }
        //                                else
        //                                {
        //                                    returnString = "Failed";
        //                                }
        //                            }
        //                            else
        //                            {
        //                                returnString = "Overlapped";
        //                            }
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    returnString = "Overlapped";
        //                }
        //            }
        //        }
        //    }


        //    return returnString;
        //}

        //// convert view model to main model
        //public AllocateClassRoom ConvertMainModel(AllocateClassroomViewModel allocateClassroomViewModel)
        //{
        //    AllocateClassRoom allocateClassRoom = new AllocateClassRoom();

        //    allocateClassRoom.DepartmentId = allocateClassroomViewModel.DepartmentId;
        //    allocateClassRoom.CourseId = allocateClassroomViewModel.CourseId;
        //    allocateClassRoom.RoomId = allocateClassroomViewModel.RoomId;
        //    allocateClassRoom.DayId = allocateClassroomViewModel.DayId;

        //    if (allocateClassroomViewModel.FromFormat.Equals("AM") && 
        //        allocateClassroomViewModel.ToFormat.Equals("AM"))
        //    {
        //        if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = 0;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = 0;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = 0;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = 0;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //    }
        //    else if (allocateClassroomViewModel.FromFormat.Equals("PM") &&
        //             allocateClassroomViewModel.ToFormat.Equals("PM"))
        //    {
        //        if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin; 
        //        }
        //        else if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour + 12;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour + 12;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour + 12;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour + 12;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //    }
        //    else if (allocateClassroomViewModel.FromFormat.Equals("AM") &&
        //             allocateClassroomViewModel.ToFormat.Equals("PM"))
        //    {
        //        if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = 0;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = 0;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour + 12;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour + 12;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //    }
        //    else if (allocateClassroomViewModel.FromFormat.Equals("PM") &&
        //             allocateClassroomViewModel.ToFormat.Equals("AM"))
        //    {
        //        if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = 0;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour+12;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin; 
        //        }
        //        else if (allocateClassroomViewModel.FromHour == 12 && allocateClassroomViewModel.ToHour != 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = allocateClassroomViewModel.ToHour;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin;  
        //        }
        //        else if (allocateClassroomViewModel.FromHour != 12 && allocateClassroomViewModel.ToHour == 12)
        //        {
        //            allocateClassRoom.FromHour = allocateClassroomViewModel.FromHour+12;
        //            allocateClassRoom.FromMin = allocateClassroomViewModel.FromMin;
        //            allocateClassRoom.ToHour = 0;
        //            allocateClassRoom.ToMin = allocateClassroomViewModel.ToMin; 
        //        }
        //    }

        //    return allocateClassRoom;
        //}

        //// time list for check time overlap
        //public List<int> MakeListToCheckTimeOverlap(AllocateClassRoom allocationClassRoom)
        //{
        //    List<AllocateClassRoom> classRooms = allocationClassroomGateway.GetAllTime(allocationClassRoom);
        //    List<int> times = new List<int>();

        //    foreach (AllocateClassRoom items in classRooms)
        //    {
        //        int fromHour = items.FromHour;
        //        int toHour = items.ToHour;

        //        if (toHour - fromHour > 1)
        //        {
        //            for (int i = fromHour; i < toHour; i++)
        //            {
        //                times.Add(i);
        //            }
        //        }
        //        else if (toHour - fromHour == 1)
        //        {
        //            times.Add(fromHour);
        //        }
        //    }

        //    return times;
        //}

        //// check overlap found
        //public bool CheckClassOverlapped(AllocateClassRoom allocateClassRoom, List<int> times)
        //{
        //    int fromHour = allocateClassRoom.FromHour;
        //    int toHour = allocateClassRoom.ToHour;
        //    int count = 0;

        //    if (toHour - fromHour > 1)
        //    {
        //        for (int i = fromHour; i < toHour; i++)
        //        {
        //            foreach (int allTimes in times)
        //            {
        //                if (i == allTimes)
        //                {
        //                    count++;
        //                }
        //            }
        //        }
        //    }
        //    else if(toHour - fromHour == 1)
        //    {
        //        foreach (int allTimes in times)
        //        {
        //            if (fromHour == allTimes)
        //            {
        //                count++;
        //            }
        //        }
        //    }

        //    if (count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //// if CheckClassOverlapped is false that means we have to check minites
        //public bool CheckOverlapByMinFromTime(AllocateClassRoom allocateClassRoom)
        //{
        //    int fromHour = allocateClassRoom.FromHour;
        //    int fromMin = allocateClassRoom.FromMin;


        //    // check new from time is matched with existing time
        //    if (allocationClassroomGateway.ToTimeIsExists(allocateClassRoom))
        //    {
        //        int toMin = allocationClassroomGateway.GetToTimeMinByFromHour(allocateClassRoom);

        //        if (fromMin < toMin)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
            
        //}

        //// if CheckClassOverlapped is false that means we have to check minites
        //public bool CheckOverlapByMinToTime(AllocateClassRoom allocateClassRoom)
        //{
        //    int toHour = allocateClassRoom.ToHour;
        //    int toMin = allocateClassRoom.ToMin;

        //    // check new from time is matched with existing time
        //    if (allocationClassroomGateway.FromTimeIsExists(allocateClassRoom))
        //    {
        //        int fromMin = allocationClassroomGateway.GetFromTimeMinByToHour(allocateClassRoom);

        //        if (toMin > fromMin)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
            
        //}

        //// ------------------------------------------------------------//
        ////to check another room, same day, same course
        //// time list for check time overlap on same 
        //public List<int> MakeListOfTimeForSameDayAndSameCourse(AllocateClassRoom allocationClassRoom)
        //{
        //    List<AllocateClassRoom> classRooms = allocationClassroomGateway.GetAllTimeByCourseAndDay(allocationClassRoom);
        //    List<int> times = new List<int>();

        //    foreach (AllocateClassRoom items in classRooms)
        //    {
        //        int fromHour = items.FromHour;
        //        int toHour = items.ToHour;

        //        if (toHour - fromHour > 1)
        //        {
        //            for (int i = fromHour; i < toHour; i++)
        //            {
        //                times.Add(i);
        //            }
        //        }
        //        else if (toHour - fromHour == 1)
        //        {
        //            times.Add(fromHour);
        //        }
        //    }

        //    return times;
        //}


        //// check overlap found on another room in same day same course
        //public bool CheckClassOverlapOnAnotherRoomSameDay(AllocateClassRoom allocateClassRoom, List<int> times)
        //{
        //    int fromHour = allocateClassRoom.FromHour;
        //    int toHour = allocateClassRoom.ToHour;
        //    int count = 0;

        //    if (toHour - fromHour > 1)
        //    {
        //        for (int i = fromHour; i < toHour; i++)
        //        {
        //            foreach (int allTimes in times)
        //            {
        //                if (i == allTimes)
        //                {
        //                    count++;
        //                }
        //            }
        //        }
        //    }
        //    else if (toHour - fromHour == 1)
        //    {
        //        foreach (int allTimes in times)
        //        {
        //            if (fromHour == allTimes)
        //            {
        //                count++;
        //            }
        //        }
        //    }

        //    if (count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        //// if CheckClassOverlapped is false that means we have to check minites
        //public bool CheckOverlapByMinFromTimeSameDayAndSameCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    int fromHour = allocateClassRoom.FromHour;
        //    int fromMin = allocateClassRoom.FromMin;


        //    // check new from time is matched with existing time
        //    if (allocationClassroomGateway.ToTimeIsExistsSameDayAndCourse(allocateClassRoom))
        //    {
        //        int toMin = allocationClassroomGateway.GetToTimeMinByFromHourSameDaySameCourse(allocateClassRoom);

        //        if (fromMin < toMin)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        //// if CheckClassOverlapped is false that means we have to check minites
        //public bool CheckOverlapByMinToTimeSameDayAndSameCourse(AllocateClassRoom allocateClassRoom)
        //{
        //    int toHour = allocateClassRoom.ToHour;
        //    int toMin = allocateClassRoom.ToMin;

        //    // check new from time is matched with existing time
        //    if (allocationClassroomGateway.FromTimeIsExistsForSameDayAndCourse(allocateClassRoom))
        //    {
        //        int fromMin = allocationClassroomGateway.GetFromTimeMinByToHourSameDayAndCourse(allocateClassRoom);

        //        if (toMin > fromMin)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}

        // ------------------------------------------------------------//

        //VIEW CLASS ALLOCATION
        public List<ViewClassScheduleAndAllocationViewModel> GetClassScheduleByDepartment(int departmentId)
        {
            List<ViewClassScheduleViewModel> classScehdules =
                allocationClassroomGateway.GetAllocateClassRoomsByDepartmentId(departmentId);
            List<ViewClassScheduleAndAllocationViewModel> models = new List<ViewClassScheduleAndAllocationViewModel>();

            int total = 0;
            int count = 0;

            foreach (ViewClassScheduleViewModel items in classScehdules)
            {
                total = models.Count;

                for (int i = 0; i < total; i++)
                {
                    if (models[i].CourseCode.Equals(items.CourseCode))
                    {
                        models[i].CourseCode = items.CourseCode;
                        models[i].CourseName = items.CourseName;
                        models[i].ScheduleList = models[i].ScheduleList + "</br>" + ConvertSpecificFormat(items);
                        count++;
                        break;
                    }
                    
                }

                if (total == 0)
                {
                    if (items.StartTime.Equals("") && items.EndTime.Equals(""))
                    {
                        ViewClassScheduleAndAllocationViewModel viewModel =
                            new ViewClassScheduleAndAllocationViewModel();

                        viewModel.CourseCode = items.CourseCode;
                        viewModel.CourseName = items.CourseName;
                        viewModel.ScheduleList = "Not Allocated Yet";

                        models.Add(viewModel);
                    }
                    else
                    {
                        ViewClassScheduleAndAllocationViewModel viewModel =
                            new ViewClassScheduleAndAllocationViewModel();

                        viewModel.CourseCode = items.CourseCode;
                        viewModel.CourseName = items.CourseName;
                        viewModel.ScheduleList = ConvertSpecificFormat(items);

                        models.Add(viewModel);
                    }
                }
                else if(count == 0)
                {
                    if (items.StartTime.Equals("") && items.EndTime.Equals(""))
                    {
                        ViewClassScheduleAndAllocationViewModel viewModel =
                            new ViewClassScheduleAndAllocationViewModel();

                        viewModel.CourseCode = items.CourseCode;
                        viewModel.CourseName = items.CourseName;
                        viewModel.ScheduleList = "Not Allocated Yet";

                        models.Add(viewModel);
                    }
                    else
                    {
                        ViewClassScheduleAndAllocationViewModel viewModel =
                            new ViewClassScheduleAndAllocationViewModel();

                        viewModel.CourseCode = items.CourseCode;
                        viewModel.CourseName = items.CourseName;
                        viewModel.ScheduleList = ConvertSpecificFormat(items);

                        models.Add(viewModel);
                    }
                }

                count = 0;
            }

            return models;
        }
 
        // set time format for view schedule
        public string ConvertSpecificFormat(ViewClassScheduleViewModel model)
        {
            if (!model.StartTime.Equals("") && !model.EndTime.Equals(""))
            {
                return "R. No: " + model.RoomNo + ", " + model.DayName + ", "+model.StartTime+" - "+model.EndTime;
            }
            else
            {
                return null;
            }
            
        }
  
    }

    
}