using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseScheduler
{
    public class course : activity
    {
        int enrollment;
        int capacity;
        string courseCode;
        string shortTitle;
        string longTitle;
        string beginTime;
        string endTime;
        string daysMeeting;
        string building;
        string room;

        public course()
            : base()
        {
            //initialize course
        }
        public course(int newEnrollment, int newCapacity, string newCourseCode, string newShortTitle, string newLongTitle, string newBeginTime, string newEndTime, string newDaysMeeting,
        string newBuilding, string newRoom)
        {
            enrollment = newEnrollment;
            capacity = newCapacity;
            courseCode = newCourseCode;
            shortTitle = newShortTitle;
            longTitle = newLongTitle;
            beginTime = newBeginTime;
            endTime = newEndTime;
            daysMeeting = newDaysMeeting;
            building = newBuilding;
            room = newRoom;
        }
        public course(course copyCourse)
        {
            enrollment = copyCourse.enrollment;
            capacity = copyCourse.capacity;
            courseCode = copyCourse.courseCode;
            shortTitle = copyCourse.shortTitle;
            longTitle = copyCourse.longTitle;
            beginTime = copyCourse.beginTime;
            endTime = copyCourse.endTime;
            daysMeeting = copyCourse.daysMeeting;
            building = copyCourse.building;
            room = copyCourse.room;
        }
        public string getCourseCode()
        {
            return courseCode;
        }
        public string getShortTitle()
        {
            return shortTitle;
        }
        public string getLongTitle()
        {
            return longTitle;
        }
        public string getStartTime()
        {
            return beginTime;
        }
        public string getEndTime()
        {
            return endTime;
        }
        public string getDays()
        {
            return daysMeeting;
        }
    }
}
