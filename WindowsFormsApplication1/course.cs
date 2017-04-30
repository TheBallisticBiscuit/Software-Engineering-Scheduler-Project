using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseScheduler
{
    public class course
    {
        protected int enrollment;
        protected int capacity;
        protected string courseCode;
        protected string shortTitle;
        protected string longTitle;
        protected string beginTime;
        protected string endTime;
        protected string daysMeeting;
        protected string building;
        protected string room;

        public course()
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

        public string getBuilding()
        {
            return building;
        }
        public string getRoom()
        {
            return room;
        }

        public string getEnrollment()
        {
            return enrollment.ToString();

        }

        public string getCapacity()
        {
            return capacity.ToString();
        }

        // Gets the start time from military to regular time.
        public string getConvStartTime()
        {
            if(beginTime != "NULL")
            {
                string[] temp = beginTime.Split(':');
                int newVal;

                if (Int32.Parse(temp[0]) > 12)
                {
                    newVal = Int32.Parse(temp[0]) - 12;
                }
                else
                {
                    newVal = Int32.Parse(temp[0]);
                }
                temp[0] = newVal.ToString();
                return temp[0] +":"+ temp[1];
             }
            return beginTime;
        }

        // Gets the end time from military to regular time.
        public string getConvEndTime()
        {
            if (endTime != "NULL")
            {
                string[] temp = endTime.Split(':');
                int newVal;

                if (Int32.Parse(temp[0]) > 12)
                {
                    newVal = Int32.Parse(temp[0]) - 12;
                }
                else
                {
                    newVal = Int32.Parse(temp[0]);
                }
                temp[0] = newVal.ToString();
                return temp[0] +":"+ temp[1];
            }
            return endTime;
        }

        // Checks to see if valid times are entered in the course.
        // Used to check to see if an extracurricular was entered with
        // correct parameters.
        public bool correctTime()
        {
            string[] strt = this.getStartTime().Split(':');
            string[] end = this.getEndTime().Split(':');
            int strtInt,endInt ;
            foreach (string str in strt)
            {
                if (!Int32.TryParse(str, out strtInt))
                {
                    return true;
                }
            }
            foreach (string str in end)
            {
                if (!Int32.TryParse(str, out endInt))
                {
                    return true;
                }
            }

            return false;
        }

        public bool isEditable() { return false; } //overwritten in extracurricular, indicates whether the course is an extracurricular or a class
    }
}
